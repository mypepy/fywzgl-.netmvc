using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
   public class GoodsDal
    {
        public static bool Insert(goods m)
        {
            using (MMEntities db = new MMEntities())
            {
                db.goods.Add(m);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(goods m)
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
                db.goods.Remove(db.goods.Find(id));
                return db.SaveChanges() > 0;
            }
        }

        public static goods Getgoods(int id)
        {
            using (MMEntities db = new MMEntities())
            {
                return db.goods.Find(id);
            }
        }

        public static List<goods> GetList(goods modelWhere,string SearchGname, int pageSize, int curIndex, out int count,int tid=0)
        {
            using (MMEntities db = new MMEntities())
            {
                var lists = db.goods.Include("type");
                if (!string.IsNullOrEmpty(SearchGname)||tid>0)
                {
                    var a = lists.Where(o => tid == 0 || o.tid == tid)
                        .Where(t => t.gname.Contains(SearchGname));
                    a = a.OrderBy(m => m.gid).Skip(pageSize * (curIndex - 1)).Take(pageSize);
                    count = a.Count();
                    return a.ToList();
                }
                count = lists.Count();
                var Pages = lists.OrderBy(m => m.gid).Skip(pageSize * (curIndex - 1)).Take(pageSize);
                return Pages.ToList();
            }
        }


    }
}
