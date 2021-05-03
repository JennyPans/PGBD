using System;
using System.Collections.Generic;

#nullable disable

namespace PopupStore.DAL.DB
{
    public partial class Product
    {
        public Product()
        {
            SellProductRels = new HashSet<SellProductRel>();
        }

        public int Id { get; set; }
        public int PriceId { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public virtual Price Price { get; set; }
        public virtual ICollection<SellProductRel> SellProductRels { get; set; }
    }
}
