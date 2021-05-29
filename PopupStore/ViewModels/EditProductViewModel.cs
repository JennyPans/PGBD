using System;
using System.Collections.Generic;
using System.Text;

namespace PopupStore.ViewModels
{
    /// <summary>
    /// ViewModel pour l'édition d'un produit
    /// </summary>
    class EditProductViewModel
    {
        public DAL.DB.Product Product { get; set; }
        public List<DAL.DB.Price> Prices { get; set; }
    }
}
