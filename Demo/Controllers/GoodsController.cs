using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class GoodsController : Controller
    {
        private MMEntities db = new MMEntities();

        // GET: Goods
        public ActionResult Index(string SearchGname, int pageSize = 5, int curIndex = 1, int tid=0)
        {
            int count=0;
         
            //方法count引用变量
            var lists = GoodsBll.GetList(new goods(), SearchGname, pageSize, curIndex, out count,tid);
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageSize);
            ViewBag.pagecount = pagecount;
            ViewBag.curIndex = curIndex;
            ViewBag.tid = new SelectList(db.type, "tid", "tname");
            ViewBag.action = "/goods/Index";
            ViewBag.SearchGname = SearchGname;
            return View(lists);
        }
       
        public ActionResult Edit(int gid = 0)
        {
            goods model = new goods();
            if (gid > 0)
            {
                model = GoodsBll.Getgoods(gid);
            }
            //绑定下拉框
            goods goods = db.goods.Find(gid);
            ViewBag.tid = new SelectList(db.type, "tid", "tname");
            return View(model);
        }
      
        [HttpPost]

        public ActionResult DoEdit(goods m,int gid = 0)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase f = Request.Files["uploadFileName"];
                string extName = System.IO.Path.GetExtension(f.FileName);
                if (extName != ".jpeg" && extName != ".gif" && extName != ".jpg" && extName != ".png" && extName != ".JPG" && extName != ".PNG" && extName != ".JPEG" && extName != ".GIF")
                {
                    //返回前一页
                    return Content("<script>alert('文件格式不合适，请重新上传');history.go(-1);</script>");
                }
              
                f.SaveAs(Server.MapPath("~/img/upload/" + f.FileName));
                m.img =f.FileName;
            }
            if (m.gid > 0)
            {
                GoodsBll.Update(m);
            }
            else
            {
                GoodsBll.Insert(m);
            }
         
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int gid = 0)
        {

            if (gid > 0)
            {
                GoodsBll.Delete(gid);
            }
            return RedirectToAction("Index");
        }
    }
}