using System;
using System.Collections.Generic;

#nullable disable

namespace PopupStore.DAL.DB
{
    public partial class Price
    {
        public Price()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int Value { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
