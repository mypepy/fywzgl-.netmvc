using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
  public  class UsersBll
    {
        public static bool Insert(users m)
        {
            return UsersDal.Insert(m);
        }

        public static bool Update(users m)
        {
            return UsersDal.Update(m);
        }

        public static bool Delete(int id)
        {
            return UsersDal.Delete(id);
        }

        public static users Getusers(int id)
        {
            return UsersDal.Getusers(id);
        }

        public static List<users> GetList(users modelWhere, string SearchUname, int pageSize, int curIndex, out int count)
        {
            return UsersDal.GetList(modelWhere, SearchUname, pageSize, curIndex, out count);
        }
        public static users Login(users modelWhere)
        {
            return UsersDal.Login(modelWhere);
        }
    }
}
