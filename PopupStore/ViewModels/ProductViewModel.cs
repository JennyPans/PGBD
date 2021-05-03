using System;
using System.Collections.Generic;
using System.Text;

namespace PopupStore.UI.ViewModels
{
    class ProductViewModel
    {
        public List<DAL.DB.Product> Products { get; set; }
        public List<DAL.DB.Price> Prices { get; set; }
    }
}
