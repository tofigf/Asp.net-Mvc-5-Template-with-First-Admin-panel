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
    public class StatsController : Controller
    {
        private EscanorEntities db = new EscanorEntities();

        // GET: Manage/Stats
        public ActionResult Index()
        {
            return View(db.Stats.ToList());
        }

        // GET: Manage/Stats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stat stat = db.Stats.Find(id);
            if (stat == null)
            {
                return HttpNotFound();
            }
            return View(stat);
        }

        // GET: Manage/Stats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Stats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Icon,Value")] Stat stat)
        {
            if (ModelState.IsValid)
            {
                db.Stats.Add(stat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stat);
        }

        // GET: Manage/Stats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stat stat = db.Stats.Find(id);
            if (stat == null)
            {
                return HttpNotFound();
            }
            return View(stat);
        }

        // POST: Manage/Stats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Icon,Value")] Stat stat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stat);
        }

        // GET: Manage/Stats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stat stat = db.Stats.Find(id);
            if (stat == null)
            {
                return HttpNotFound();
            }
            return View(stat);
        }

        // POST: Manage/Stats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stat stat = db.Stats.Find(id);
            db.Stats.Remove(stat);
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
