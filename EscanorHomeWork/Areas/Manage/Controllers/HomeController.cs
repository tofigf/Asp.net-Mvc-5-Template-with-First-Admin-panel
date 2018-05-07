using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using EscanorHomeWork.Models;

namespace EscanorHomeWork.Areas.Manage.Controllers
{
    public class HomeController : Controller
    {
        EscanorEntities db = new EscanorEntities();
        // GET: Manage/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(Admin admin)
        {
            //bool check = Crypto.VerifyHashedPassword("AOwcfKpoUJbtwaDwLCY2+mzH1034c3u9rB0j23DiU3S2K21GcvTxDes/v29E4gsc1A==", "789");
            // return Content(check.ToString());
            //string hashed = Crypto.HashPassword("789");
            //return Content(hashed);
            Admin loginned = db.Admins.FirstOrDefault(s => s.Email == admin.Email);
            if (loginned != null)
            {
                if (Crypto.VerifyHashedPassword(loginned.Password, admin.Password))
                {
                    Session["loginned"] = true;
                    Session["Admin"] = loginned;
                    return RedirectToAction("index", "dashboard");
                }
            }
            Session["LoginError"] = true;
            return RedirectToAction("index");
        } 
    }
}