using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PCDetailsWeb.Models;

namespace PCDetailsWeb.Controllers
{
    public class monitorController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /monitor/
        public ActionResult Index()
        {
            var tblmonitor = db.tblmonitor.Include(t => t.tblvendor);
            return View(tblmonitor.ToList());
        }

        // GET: /monitor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblmonitor tblmonitor = db.tblmonitor.Find(id);
            if (tblmonitor == null)
            {
                return HttpNotFound();
            }
            return View(tblmonitor);
        }

        // GET: /monitor/Create
        public ActionResult Create()
        {
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name");
            return View();
        }

        // POST: /monitor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,serialno,version,fkvendor")] tblmonitor tblmonitor)
        {
            if (ModelState.IsValid)
            {
                db.tblmonitor.Add(tblmonitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblmonitor.fkvendor);
            return View(tblmonitor);
        }

        // GET: /monitor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblmonitor tblmonitor = db.tblmonitor.Find(id);
            if (tblmonitor == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblmonitor.fkvendor);
            return View(tblmonitor);
        }

        // POST: /monitor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,serialno,version,fkvendor")] tblmonitor tblmonitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblmonitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblmonitor.fkvendor);
            return View(tblmonitor);
        }

        // GET: /monitor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblmonitor tblmonitor = db.tblmonitor.Find(id);
            if (tblmonitor == null)
            {
                return HttpNotFound();
            }
            return View(tblmonitor);
        }

        // POST: /monitor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblmonitor tblmonitor = db.tblmonitor.Find(id);
            db.tblmonitor.Remove(tblmonitor);
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
