using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PopupStore.BU
{
    /// <summary>
    /// Service utilisé pour accéder ou mettre à jour les données des prix
    /// </summary>
    class PriceService
    {
        /// <summary>
        /// Renvoie tous les prix
        /// </summary>
        /// <returns>Liste de prix</returns>
        public static List<DAL.DB.Price> GetPrices()
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Prices.ToList();
            }
        }
        /// <summary>
        /// Récupérer un prix par son id
        /// </summary>
        /// <param name="id">id du prix</param>
        /// <returns>Le prix ou null</returns>
        public static DAL.DB.Price GetPrice(int id)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Prices.Include("Products").Where(p => p.Id == id).SingleOrDefault();
            }
        }
        /// <summary>
        /// Récupérer un prix par sa valeur
        /// </summary>
        /// <param name="value">La valeur du prix</param>
        /// <returns>Le prix ou null</returns>
        public static DAL.DB.Price GetPriceByValue(int value)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Prices.Where(p => p.Value == value).SingleOrDefault();
            }
        }
        /// <summary>
        /// Récupérer le prix par sa couleur
        /// </summary>
        /// <param name="color">Couleur du prix en format #00000000</param>
        /// <returns>Le prix ou null</returns>
        public static DAL.DB.Price GetPriceByColor(string color)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Prices.Where(p => p.Color == color).SingleOrDefault();
            }
        }
        /// <summary>
        /// Créer un prix
        /// </summary>
        /// <param name="price">Un objet contenant les valeurs</param>
        public static void CreatePrice(DAL.DB.Price price)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                db.Prices.Add(price);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Supprimer un prix
        /// </summary>
        /// <param name="price">Le prix à supprimer</param>
        public static void DeletePrice(DAL.DB.Price price)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                db.Prices.Remove(price);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Mettre à jour un prix
        /// </summary>
        /// <param name="id">l'id du prix</param>
        /// <param name="value">La valeur du prix</param>
        /// <param name="color">La couleur du prix</param>
        public static void UpdatePrice(int id, int value, string color)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                DAL.DB.Price price = db.Prices.Find(id);
                if (price != null)
                {
                    price.Value = value;
                    price.Color = color;
                    db.SaveChanges();
                }
            }
        }
    }
}
