using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Demo.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index(string SearchUname, int pageSize = 5, int curIndex = 1)
        {
            int count = 0;
            //方法count引用变量
            var lists = UsersBll.GetList(new users(), SearchUname, pageSize, curIndex, out count);
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageSize);
            ViewBag.pagecount = pagecount;
            ViewBag.curIndex = curIndex;
            ViewBag.action = "/Users/Index";
            ViewBag.SearchUname = SearchUname;
            return View(lists);
        }
      

        public ActionResult Edit(int uid = 0)
        {
            users model = new users();
            model.birth = DateTime.Now;
            if (uid > 0)
            {
                model = UsersBll.Getusers(uid);
            }
            return View(model);
        }
        public ActionResult Reg(int uid = 0)
        {
            users model = new users();
            model.birth = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(users m)
        {
           
            if (m.uid > 0)
            {
                UsersBll.Update(m);
            }
            else
            {
                UsersBll.Insert(m);
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int uid = 0)
        {
          
            if (uid > 0)
            {
                UsersBll.Delete(uid);
            }
            return RedirectToAction("Index");
        }
        //登录
        public ActionResult login()
        {
            return View();
        }
        public ActionResult DoLogin(users m)
        {
            var model = UsersBll.Login(m);
            if (model != null && model.uid > 0)
            {
                //保持登录状态
                //true 有效期是永久（根据配置文件的时间，单位是分钟）
                FormsAuthentication.SetAuthCookie(model.uname, true);
                //false 有效期是会话的
                //FormsAuthentication.SetAuthCookie(model.uname, false);
                //跨控制器
                //return Redirect("/Home/Index");
                return Content("<script>alert('登陆成功');window.open('" + Url.Content("/Home/Index") + "', '_self')</script>", "text/html");

            }
            else
            {

                return Content("<script>alert('用户名或密码有误！');history.go(-1);</script>");
            }

        }
        //退出
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
        //注册
     
        public ActionResult DoReg(users m)
        {
          
                UsersBll.Insert(m);
            return Content("<script>alert('注册成功');window.open('" + Url.Content("/Users/login") + "', '_self')</script>", "text/html");
        
        }
    }
}