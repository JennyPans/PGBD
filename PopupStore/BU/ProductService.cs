using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
                return db.Products.Include("Price").SingleOrDefault(p => p.Label.ToUpper() == name.ToUpper());
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
        public static void AddQuantity(int productId, int quantity)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                DAL.DB.Product product = db.Products.Find(productId);
                if (product != null)
                {
                    product.Quantity += quantity;
                    db.SaveChanges();
                }
            }
        }
        public static void RemoveQuantity(int productId, int quantity)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                DAL.DB.Product product = db.Products.Find(productId);
                if (product != null)
                {
                    Debug.WriteLine(product.Quantity);
                    product.Quantity -= quantity;
                    Debug.WriteLine(product.Quantity);
                    db.SaveChanges();
                }
            }
        }
    }
}
