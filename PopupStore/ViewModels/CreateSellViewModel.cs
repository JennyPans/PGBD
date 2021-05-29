using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PopupStore.ViewModels
{
    /// <summary>
    /// ViewModel utilisé pour gérer la création de vente
    /// </summary>
    class CreateSellViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DAL.DB.SellProductRel> SellProductRels { get; set; }
        public DAL.DB.Sell Sell { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Calculer le prix pour une ligne
        /// </summary>
        /// <param name="sellProductRel"></param>
        /// <returns>Le prox pour une ligne</returns>
        public int calculPrice(DAL.DB.SellProductRel sellProductRel)
        {
            return sellProductRel.Quantity * sellProductRel.Product.Price.Value;
        }
        /// <summary>
        /// Calculer le prix total de la vente
        /// </summary>
        public void calculTotal()
        {
            Sell.AmountTotal = 0;
            foreach (var item in SellProductRels)
            {
                Sell.AmountTotal += item.Product.Price.Value * item.Quantity;
            }
            OnPropertyChanged("Sell");
        }
        /// <summary>
        /// Supprimer une ligne de détail de la vente
        /// </summary>
        /// <param name="sellProductRel">La ligne à supprimer</param>
        public void removeSellProductRel(DAL.DB.SellProductRel sellProductRel)
        {
            if (sellProductRel != null)
            {
                SellProductRels.Remove(sellProductRel);
                calculTotal();
            }
        }
        /// <summary>
        /// Créer la vente
        /// </summary>
        /// <param name="paymentMode">Le mode de paiement (enum)</param>
        public void CreateSell(int paymentMode)
        {
            Sell.PaymentType = ((Enums.PaymentMode)paymentMode).ToString();
            BU.SellService.CreateSell(Sell);
            CreateSellProductRels();
        }
        /// <summary>
        /// Créer le détail de la vente
        /// </summary>
        public void CreateSellProductRels()
        {
            foreach (var item in SellProductRels)
            {
                item.SellId = Sell.Id;
            }
            BU.SellService.CreateSellProductRels(SellProductRels);
        }
        /// <summary>
        /// Vérifier si on a pas déjà une ligne contenant le produit que l'on veut ajouter
        /// </summary>
        /// <param name="productId">L'id du produit</param>
        /// <returns>Un booléan indiquant si on peut ajouter le produit à la vente</returns>
        public bool canAddProductInSell(int productId)
        {
            return SellProductRels.Where(s => s.ProductId == productId).SingleOrDefault() == null;
        }
    }
}
