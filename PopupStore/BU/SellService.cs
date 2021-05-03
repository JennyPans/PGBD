using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace PopupStore.BU
{
    class SellService
    {
        public static List<DAL.DB.Sell> GetSellsWithDetail()
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Sells.Include(x => x.SellProductRels).ThenInclude(x => x.Product).ThenInclude(x => x.Price).ToList();
            }
        }
    }
}
