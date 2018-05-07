using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EscanorHomeWork.Models;

namespace EscanorHomeWork.Areas.Manage.Controllers
{
    public class AboutsController : Controller
    {
        private EscanorEntities db = new EscanorEntities();

        // GET: Manage/Abouts
        public ActionResult Index()
        {
            return View(db.Abouts.ToList());
        }

        // GET: Manage/Abouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

     

        // GET: Manage/Abouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Manage/Abouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,PreTitle,Title,Text,Signature")] About about)
        {
            if (ModelState.IsValid)
            {
                db.Entry(about).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

   

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
