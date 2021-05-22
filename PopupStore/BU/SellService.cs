using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PopupStore.BU
{
    class SellService
    {
        public static List<DAL.DB.Sell> GetSellsWithDetail()
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Sells.Include(x => x.SellProductRels).ThenInclude(x => x.Product).ThenInclude(x => x.Price).ToList();
            }
        }
        public static void CreateSell(DAL.DB.Sell sell)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                db.Sells.Add(sell);
                db.SaveChanges();
            }
        }
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
