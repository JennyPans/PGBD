using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace PopupStore.UI.ViewModels
{
    /// <summary>
    /// ViewModel pour gérer les prix
    /// </summary>
    class PriceViewModel
    {
        public List<DAL.DB.Price> Prices { get; set; }
    }
}