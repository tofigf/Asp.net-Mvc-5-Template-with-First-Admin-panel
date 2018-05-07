using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EscanorHomeWork.Models;

namespace EscanorHomeWork.Controllers
{
    public class HomeController : Controller
    {
        EscanorEntities db = new EscanorEntities();
        public ActionResult Index()
        {
            ViewBag.Setting = db.Settings.First();
            ViewHome model = new ViewHome
            {
                Features = db.Features.ToList(),
                About =db.Abouts.FirstOrDefault(),
                Services =db.Services.ToList(),
                Skills =db.Skills.ToList(),
                Categories =db.Categories.ToList(),
                Projects =db.Projects.ToList(),
                Stats =db.Stats.ToList(),
                Packages =db.Packages.ToList(),
                Packageinfos =db.Packageinfos.ToList(),
                Feedbacks =db.Feedbacks.ToList(),
                Posts =db.Posts.ToList()
            };
            return View(model);
        }

    
    }
}