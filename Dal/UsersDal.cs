using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
  public  class UsersDal
    {
        public static bool Insert(users m)
        {
            using (MMEntities db = new MMEntities())
            {
                db.users.Add(m);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(users m)
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
                db.users.Remove(db.users.Find(id));
                return db.SaveChanges() > 0;
            }
        }

        public static users Getusers(int id)
        {
            using (MMEntities db = new MMEntities())
            {
                return db.users.Find(id);
            }
        }

        public static List<users> GetList(users modelWhere, string SearchUname, int pageSize, int curIndex, out int count)
        {
            using (MMEntities db = new MMEntities())
            {
                var lists = db.users;
                if (!string.IsNullOrEmpty(SearchUname))
                {

                    var a = lists.Where(t => t.uname.Contains(SearchUname));
                    a = a.OrderBy(m => m.uid).Skip(pageSize * (curIndex - 1)).Take(pageSize);
                    count = a.Count();
                    return a.ToList();
                }

                lists.Where(o => string.IsNullOrEmpty(modelWhere.pwd) || o.uname.Contains(modelWhere.uname));
                count = lists.Count();
                var Pages = lists.OrderBy(m => m.uid).Skip(pageSize * (curIndex - 1)).Take(pageSize);
                return Pages.ToList();
            }
        }
        public static users Login(users ModelWhere)
        {
            using (MMEntities db = new MMEntities())
            {
                return db.users.Where(t => t.uname == ModelWhere.uname && t.pwd == ModelWhere.pwd).FirstOrDefault();

            }
        }
    }
}
