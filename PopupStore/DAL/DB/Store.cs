using System;
using System.Collections.Generic;

#nullable disable

namespace PopupStore.DAL.DB
{
    public partial class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
    }
}
