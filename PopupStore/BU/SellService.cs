using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace PopupStore.BU
{
    class SellService
    {
        public static List<DAL.DB.Sell> GetSells()
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Sells.Include("SellProductRels").ToList();
            }
        }
    }
}
