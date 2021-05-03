using System;
using System.Collections.Generic;

#nullable disable

namespace PopupStore.DAL.DB
{
    public partial class SellProductRel
    {
        public int SellId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sell Sell { get; set; }
    }
}
