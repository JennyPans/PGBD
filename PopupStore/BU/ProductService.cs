using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace PopupStore.BU
{
    /// <summary>
    /// Service pour accéder, créer ou mettre à jour des produits
    /// </summary>
    class ProductService
    {
        /// <summary>
        /// Récupérer les produits sous format de liste
        /// </summary>
        /// <returns>Liste de produits incluant les prix</returns>
        public static List<DAL.DB.Product> GetProducts()
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Products.Include("Price").ToList();
            }
        }
        /// <summary>
        /// Récupérer un produit par son label
        /// </summary>
        /// <param name="name">Le label</param>
        /// <returns>Le produit ou null</returns>
        public static DAL.DB.Product GetProductByLabel(string name)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Products.Include("Price").SingleOrDefault(p => p.Label.ToUpper() == name.ToUpper());
            }
        }
        /// <summary>
        /// Récupérer un produit par son nom
        /// </summary>
        /// <param name="name">Le nom du produit</param>
        /// <returns>Le produit ou null</returns>
        public static DAL.DB.Product GetProductByName(string name)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Products.SingleOrDefault(p => p.Name.ToUpper() == name.ToUpper());
            }
        }
        /// <summary>
        /// Récupérer un produit sur base de son id
        /// </summary>
        /// <param name="productId">L'id du produit</param>
        /// <returns>Le produit ou null</returns>
        public static DAL.DB.Product GetProduct(int productId)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Products.Find(productId);
            }
        }
        /// <summary>
        /// Créer un produit
        /// </summary>
        /// <param name="product">Le produit à créer</param>
        public static void CreateProduct(DAL.DB.Product product)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                product.Label = product.Label.ToUpper();
                db.Products.Add(product);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Augmenter le stock d'un produit
        /// </summary>
        /// <param name="productId">Le produit</param>
        /// <param name="quantity">La quantité à ajouter</param>
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
        /// <summary>
        /// Décroitre le stock d'un produit
        /// </summary>
        /// <param name="productId">Le produit</param>
        /// <param name="quantity">La quantité à enlever</param>
        public static void RemoveQuantity(int productId, int quantity)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                DAL.DB.Product product = db.Products.Find(productId);
                if (product != null)
                {
                    product.Quantity -= quantity;
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Supprimer un produit
        /// </summary>
        /// <param name="productId">L'id du produit à supprimer</param>
        public static void DeleteProduct(int productId)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                DAL.DB.Product product = db.Products.Find(productId);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Mettre à jour un produit
        /// </summary>
        /// <param name="id">L'id du produit</param>
        /// <param name="label">Le label du produit</param>
        /// <param name="name">Le nom du produit</param>
        /// <param name="priceId">Le prix du produit</param>
        /// <param name="quantity">La quantité en stock</param>
        public static void UpdateProduct(int id, string label, string name, int priceId, int quantity)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                DAL.DB.Product product = db.Products.Find(id);
                if (product != null)
                {
                    product.Label = label;
                    product.Name = name;
                    product.PriceId = priceId;
                    product.Quantity = quantity;
                    db.SaveChanges();
                }
            }
        }
    }
}
