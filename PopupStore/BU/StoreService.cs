using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PopupStore.BU
{
    class StoreService
    {
        public static DAL.DB.Store GetStore()
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                return db.Stores.Single();
            }
        }
        public static void UpdateStore(int id, String name, DateTime dateFrom, DateTime dateTo)
        {
            using (DAL.DB.PopupStoreContext db = new DAL.DB.PopupStoreContext())
            {
                DAL.DB.Store store = db.Stores.Find(id);
                if (store != null)
                {
                    store.Name = name;
                    store.PeriodFrom = dateFrom;
                    store.PeriodTo = dateTo;
                    db.SaveChanges();
                }
            }
        }
    }
}
