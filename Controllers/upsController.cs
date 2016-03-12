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
    public class upsController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /ups/
        public ActionResult Index()
        {
            var tblups = db.tblups.Include(t => t.tblvendor);
            return View(tblups.ToList());
        }

        // GET: /ups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblups tblups = db.tblups.Find(id);
            if (tblups == null)
            {
                return HttpNotFound();
            }
            return View(tblups);
        }

        // GET: /ups/Create
        public ActionResult Create()
        {
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name");
            return View();
        }

        // POST: /ups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,serialno,version,fkvendor")] tblups tblups)
        {
            if (ModelState.IsValid)
            {
                db.tblups.Add(tblups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblups.fkvendor);
            return View(tblups);
        }

        // GET: /ups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblups tblups = db.tblups.Find(id);
            if (tblups == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblups.fkvendor);
            return View(tblups);
        }

        // POST: /ups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,serialno,version,fkvendor")] tblups tblups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblups.fkvendor);
            return View(tblups);
        }

        // GET: /ups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblups tblups = db.tblups.Find(id);
            if (tblups == null)
            {
                return HttpNotFound();
            }
            return View(tblups);
        }

        // POST: /ups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblups tblups = db.tblups.Find(id);
            db.tblups.Remove(tblups);
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
