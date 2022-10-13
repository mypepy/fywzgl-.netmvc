using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
  public  class PlansBll
    {
        public static bool Insert(plans m)
        {
            return PlansDal.Insert(m);
        }

        public static bool Update(plans m)
        {
            return PlansDal.Update(m);
        }

        public static bool Delete(int id)
        {
            return PlansDal.Delete(id);
        }

        public static plans Getplans(int id)
        {
            return PlansDal.Getplans(id);
        }

        public static List<plans> GetList(plans modelWhere,string SearchPname, int pageSize, int curIndex, out int count)
        {
            return PlansDal.GetList(modelWhere, SearchPname,pageSize,curIndex,out count);
        }
    }
}
