using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HomeWork.Controllers
{
    public class HomeController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string acc, string Password)
        {

            // 登入的密碼（以 SHA1 加密）
            //Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1");

            //這一條是去資料庫抓取輸入的帳號密碼的方法請自行實做
            var r = db.客戶資料.Where(p=>p.客戶名稱==acc&&p.密碼==Password).ToList();

            if (r == null)
            {
                TempData["Error"] = "您輸入的帳號不存在或者密碼錯誤!";
                return View();
            }

            // 登入時清空所有 Session 資料
            Session.RemoveAll();

            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
            //  r.客戶名稱,//你想要存放在 User.Identy.Name 的值，通常是使用者帳號
            //  DateTime.Now,
            //  DateTime.Now.AddMinutes(30),
            //  false,//將管理者登入的 Cookie 設定成 Session Cookie
            //  r.Rank.ToString(),//userdata看你想存放啥
            //  FormsAuthentication.FormsCookiePath);

            //string encTicket = FormsAuthentication.Encrypt(ticket);

            //Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            return RedirectToAction("Index", "Home");

        }
    }
}