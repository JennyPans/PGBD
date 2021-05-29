using System;
using System.Collections.Generic;
using System.Text;

namespace PopupStore.UI.ViewModels
{
    /// <summary>
    /// ViewModel pour gérer les produits et leurs prix
    /// </summary>
    class ProductViewModel
    {
        public List<DAL.DB.Product> Products { get; set; }
        public List<DAL.DB.Price> Prices { get; set; }
    }
}
