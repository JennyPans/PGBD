using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PopupStore.UI.ViewModels
{
    /// <summary>
    /// ViewModel pour gérer le résumé des ventes
    /// </summary>
    class SellViewModel
    {
        public List<DAL.DB.Sell> Sells { get; set; }
    }
}