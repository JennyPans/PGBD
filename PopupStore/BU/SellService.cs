using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PopupStore.BU
{
    /// <summary>
    /// Service utilisé pour la vente de produits
    /// </summary>
    class SellService
    {
        /// <summary>
        /// Obtenir toutes les ventes avec leurs détails : prix, produit
        /// </summary>
        /// <returns>Liste des ventes</returns>
        public static List<DAL.DB.Sell> GetSellsWithDetail()
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Sells.Include(x => x.SellProductRels).ThenInclude(x => x.Product).ThenInclude(x => x.Price).ToList();
            }
        }
        /// <summary>
        /// Créer une vente
        /// </summary>
        /// <param name="sell">La vente à créer</param>
        public static void CreateSell(DAL.DB.Sell sell)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                db.Sells.Add(sell);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Créer le détail d'une vente
        /// </summary>
        /// <param name="sellProductRels">Les lignes de détails</param>
        public static void CreateSellProductRels(ObservableCollection<DAL.DB.SellProductRel> sellProductRels)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                foreach (DAL.DB.SellProductRel sellProductRel in sellProductRels)
                {
                    BU.ProductService.RemoveQuantity(sellProductRel.ProductId, sellProductRel.Quantity);
                    // ça ne fonctionne pas sans
                    sellProductRel.Product = null;
                    sellProductRel.Sell = null;
                    db.SellProductRels.Add(sellProductRel);
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Supprimer une vente et son détail
        /// </summary>
        /// <param name="sellId">L'id de la vente</param>
        public static void DeleteSell(int sellId)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                DAL.DB.Sell sell = db.Sells.Find(sellId);
                if(sell != null)
                {
                    DeleteSellProductRels(sell.Id);
                    db.Sells.Remove(sell);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Supprimer le détail d'une vente
        /// On fait attention à remettre les produits dans le stock
        /// </summary>
        /// <param name="sellId">L'id de la vente</param>
        public static void DeleteSellProductRels(int sellId)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                // Récupérer tous les sells product rels du sell
                List<DAL.DB.SellProductRel> sellProductRels = db.SellProductRels.Where(s => s.SellId == sellId).ToList();
                foreach (var sellProductRel in sellProductRels)
                {
                    BU.ProductService.AddQuantity(sellProductRel.ProductId, sellProductRel.Quantity);
                }
                db.RemoveRange(sellProductRels);
                db.SaveChanges();
            }
        }
    }
}
