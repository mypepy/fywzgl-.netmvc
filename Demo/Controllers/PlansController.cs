using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class PlansController : Controller
    {
        // GET: Plans
        public ActionResult Index(string SearchPname,int pageSize=5, int curIndex=1)
        {
            int count = 0;
            //方法count引用变量
            var lists = PlansBll.GetList(new plans(), SearchPname,pageSize,curIndex,out count);
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageSize);
            ViewBag.pagecount = pagecount;
            ViewBag.curIndex = curIndex;
            ViewBag.action="/Plans/Index";
            ViewBag.SearchPname = SearchPname;
            return View(lists);
        }
     
        public ActionResult Edit(int pid = 0)
        {
            plans model = new plans();
            model.ptime = DateTime.Now;
            if (pid > 0)
            {
                model = PlansBll.Getplans(pid);
            }
          
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(plans m)
        {

            if (m.pid > 0)
            {
                PlansBll.Update(m);
            }
            else
            {
                PlansBll.Insert(m);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int pid = 0)
        {

            if (pid > 0)
            {
                PlansBll.Delete(pid);
            }
            return RedirectToAction("Index");
        }
    }
}