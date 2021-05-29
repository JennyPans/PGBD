using System;
using System.Collections.Generic;
using System.Text;

namespace PopupStore.ViewModels
{
    /// <summary>
    /// ViewModel pour l'édition d'un prix
    /// </summary>
    class EditPriceViewModel
    {
        public DAL.DB.Price Price { get; set; }
        public List<DAL.DB.Price> Prices { get; set; }
    }
}
