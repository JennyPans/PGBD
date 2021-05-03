using System;
using System.Collections.Generic;

#nullable disable

namespace PopupStore.DAL.DB
{
    public partial class Sell
    {
        public Sell()
        {
            SellProductRels = new HashSet<SellProductRel>();
        }

        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public string PaymentType { get; set; }
        public double AmountTotal { get; set; }

        public virtual ICollection<SellProductRel> SellProductRels { get; set; }
    }
}
