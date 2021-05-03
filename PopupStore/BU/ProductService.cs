using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PopupStore.BU
{
    class ProductService
    {
        public static List<DAL.DB.Product> GetProducts()
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Products.Include("Price").ToList();
            }
        }
        public static DAL.DB.Product GetProductByLabel(string name)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Products.SingleOrDefault(p => p.Label.ToUpper() == name.ToUpper());
            }
        }

        public static DAL.DB.Product GetProductByName(string name)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Products.SingleOrDefault(p => p.Name.ToUpper() == name.ToUpper());
            }
        }

        public static void CreateProduct(DAL.DB.Product product)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                product.Label = product.Label.ToUpper();
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public static void DeleteProduct(DAL.DB.Product product)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
