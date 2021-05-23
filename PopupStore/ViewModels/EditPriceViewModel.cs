using System;
using System.Collections.Generic;
using System.Text;

namespace PopupStore.ViewModels
{
    class EditPriceViewModel
    {
        public DAL.DB.Price Price { get; set; }
        public List<DAL.DB.Price> Prices { get; set; }
    }
}
