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
        public static DAL.DB.Price GetPriceByValue(int value)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Prices.Where(p => p.Value == value).SingleOrDefault();
            }
        }
        public static DAL.DB.Price GetPriceByColor(string color)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Prices.Where(p => p.Color == color).SingleOrDefault();
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
