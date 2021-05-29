using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace PopupStore.BU
{
    /// <summary>
    /// Service utilisé pour mettre à jour les informations du magasin
    /// </summary>
    class StoreService
    {
        /// <summary>
        /// Obtenir le magasin
        /// </summary>
        /// <returns></returns>
        public static DAL.DB.Store GetStore()
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                CreateStore();
                return db.Stores.Single();
            }
        }
        /// <summary>
        /// Mettre à jour les informations du magasin
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        public static void UpdateStore(int id, String name, DateTime dateFrom, DateTime dateTo)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                DAL.DB.Store store = db.Stores.Find(id);
                if (store != null)
                {
                    store.Name = name;
                    store.PeriodFrom = dateFrom;
                    store.PeriodTo = dateTo;
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Créer le magasin de base si il n'existe pas
        /// </summary>
        public static void CreateStore()
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                if (db.Stores.ToList().Count == 0)
                {
                    DAL.DB.Store store = new DAL.DB.Store();
                    store.Name = "My popup store";
                    store.PeriodFrom = DateTime.Today;
                    store.PeriodTo = DateTime.Today;
                    db.Stores.Add(store);
                    db.SaveChanges();
                }
            }
        }
    }
}
