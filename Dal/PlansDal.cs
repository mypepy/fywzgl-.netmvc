using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
  public  class PlansDal
    {
        public static bool Insert(plans m)
        {
            using (MMEntities db = new MMEntities())
            {
                db.plans.Add(m);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(plans m)
        {
            using (MMEntities db = new MMEntities())
            {
                db.Entry(m).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (MMEntities db = new MMEntities())
            {
                db.plans.Remove(db.plans.Find(id));
                return db.SaveChanges() > 0;
            }
        }

        public static plans Getplans(int id)
        {
            using (MMEntities db = new MMEntities())
            {
                return db.plans.Find(id);
            }
        }

     
        public static List<plans> GetList(plans modelWhere, string SearchPname, int pageSize, int curIndex, out int count)
        {
            using (MMEntities db = new MMEntities())
            {
                var lists = db.plans;
                if (!string.IsNullOrEmpty(SearchPname))
                {
                   
                 var a=lists.Where(t => t.pname.Contains(SearchPname));
                    a = a.OrderBy(m => m.pid).Skip(pageSize * (curIndex - 1)).Take(pageSize);
                    count= a.Count();
                    return a.ToList();
                }
              
                count = lists.Count();
                var Pages=lists.OrderBy(m=>m.pid).Skip(pageSize*(curIndex - 1)).Take(pageSize);
                return Pages.ToList();
            }
        }

    }
}
