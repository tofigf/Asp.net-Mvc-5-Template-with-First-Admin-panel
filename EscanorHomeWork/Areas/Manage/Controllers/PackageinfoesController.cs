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
    public class PackageinfoesController : Controller
    {
        private EscanorEntities db = new EscanorEntities();

        // GET: Manage/Packageinfoes
        public ActionResult Index()
        {
            var packageinfos = db.Packageinfos.Include(p => p.Package);
            return View(packageinfos.ToList());
        }

        // GET: Manage/Packageinfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Packageinfo packageinfo = db.Packageinfos.Find(id);
            if (packageinfo == null)
            {
                return HttpNotFound();
            }
            return View(packageinfo);
        }

        // GET: Manage/Packageinfoes/Create
        public ActionResult Create()
        {
            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name");
            return View();
        }

        // POST: Manage/Packageinfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PackageId,OrderBy,Title")] Packageinfo packageinfo)
        {
            if (ModelState.IsValid)
            {
                db.Packageinfos.Add(packageinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name", packageinfo.PackageId);
            return View(packageinfo);
        }

        // GET: Manage/Packageinfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Packageinfo packageinfo = db.Packageinfos.Find(id);
            if (packageinfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name", packageinfo.PackageId);
            return View(packageinfo);
        }

        // POST: Manage/Packageinfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PackageId,OrderBy,Title")] Packageinfo packageinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packageinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name", packageinfo.PackageId);
            return View(packageinfo);
        }

        // GET: Manage/Packageinfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Packageinfo packageinfo = db.Packageinfos.Find(id);
            if (packageinfo == null)
            {
                return HttpNotFound();
            }
            return View(packageinfo);
        }

        // POST: Manage/Packageinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Packageinfo packageinfo = db.Packageinfos.Find(id);
            db.Packageinfos.Remove(packageinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
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
