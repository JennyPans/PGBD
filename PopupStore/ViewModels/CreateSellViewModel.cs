using System;
using System.Collections.Generic;
using System.Text;

namespace PopupStore.ViewModels
{
    class CreateSellViewModel
    {
        public List<DAL.DB.SellProductRel> SellProductRels { get; set; }
        public DAL.DB.Sell Sell { get; set; }
    }
}
