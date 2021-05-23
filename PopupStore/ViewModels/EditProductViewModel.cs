using System;
using System.Collections.Generic;
using System.Text;

namespace PopupStore.ViewModels
{
    class EditProductViewModel
    {
        public DAL.DB.Product Product { get; set; }
        public List<DAL.DB.Price> Prices { get; set; }
    }
}
