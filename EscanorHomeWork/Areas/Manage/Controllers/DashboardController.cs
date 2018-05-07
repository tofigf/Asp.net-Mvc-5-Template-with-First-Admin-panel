using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EscanorHomeWork.Models;

namespace EscanorHomeWork.Areas.Manage.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Manage/Dashboard
        public ActionResult Index()
        {
            if (Session["loginned"] == null)
            {
                return RedirectToAction("index", "home");
            }
            Admin admin = Session["Admin"] as Admin;
            return View(admin);
        }
        public ActionResult Logout()
        {
            Session["loginned"] = null;
            return RedirectToAction("index","home");
        }
    }
}