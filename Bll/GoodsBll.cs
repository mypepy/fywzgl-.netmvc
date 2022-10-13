using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
   public class GoodsBll
    {
        public static bool Insert(goods m)
        {
            return GoodsDal.Insert(m);
        }

        public static bool Update(goods m)
        {
            return GoodsDal.Update(m);
        }

        public static bool Delete(int id)
        {
            return GoodsDal.Delete(id);
        }

        public static goods Getgoods(int id)
        {
            return GoodsDal.Getgoods(id);
        }

        public static List<goods> GetList(goods modelWhere, string SearchGname, int pageSize, int curIndex, out int count,int tid=0)
        {
            return GoodsDal.GetList(modelWhere,SearchGname, pageSize, curIndex, out count,tid);
        }

    }
}
