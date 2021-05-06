using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PopupStore.BU
{
    class PriceService
    {
        public static List<DAL.DB.Price> GetPrices()
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Prices.ToList();
            }
        }

        public static DAL.DB.Price GetPrice(int id)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Prices.Include("Products").Where(p => p.Id == id).SingleOrDefault();
            }
        }

        public static void CreatePrice(DAL.DB.Price price)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                db.Prices.Add(price);
                db.SaveChanges();
            }
        }

        public static void DeletePrice(DAL.DB.Price price)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                db.Prices.Remove(price);
                db.SaveChanges();
            }
        }
    }
}
