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
    class CreateSellViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DAL.DB.SellProductRel> SellProductRels { get; set; }
        public DAL.DB.Sell Sell { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int calculPrice(DAL.DB.SellProductRel sellProductRel)
        {
            return sellProductRel.Quantity * sellProductRel.Product.Price.Value;
        }
        public void calculTotal()
        {
            Sell.AmountTotal = 0;
            foreach (var item in SellProductRels)
            {
                Sell.AmountTotal += item.Product.Price.Value * item.Quantity;
            }
            OnPropertyChanged("Sell");
        }
        public void removeSellProductRel(DAL.DB.SellProductRel sellProductRel)
        {
            if (sellProductRel != null)
            {
                SellProductRels.Remove(sellProductRel);
                calculTotal();
            }
        }
        public void CreateSell(int paymentMode)
        {
            Sell.PaymentType = ((Enums.PaymentMode)paymentMode).ToString();
            BU.SellService.CreateSell(Sell);
            CreateSellProductRels();
        }
        public void CreateSellProductRels()
        {
            foreach (var item in SellProductRels)
            {
                item.SellId = Sell.Id;
            }
            BU.SellService.CreateSellProductRels(SellProductRels);
        }
        public bool canAddProductInSell(int productId)
        {
            return SellProductRels.Where(s => s.ProductId == productId).SingleOrDefault() == null;
        }
    }
}
