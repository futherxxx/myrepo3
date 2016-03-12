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
    public class staffController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /staff/
        public ActionResult Index()
        {
            var tblstaff = db.tblstaff.Include(t => t.tbldept);
            return View(tblstaff.ToList());
        }

        // GET: /staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstaff tblstaff = db.tblstaff.Find(id);
            if (tblstaff == null)
            {
                return HttpNotFound();
            }
            return View(tblstaff);
        }

        // GET: /staff/Create
        public ActionResult Create()
        {
            ViewBag.fkdept = new SelectList(db.tbldept, "id", "name");
            return View();
        }

        // POST: /staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,fkdept")] tblstaff tblstaff)
        {
            if (ModelState.IsValid)
            {
                db.tblstaff.Add(tblstaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkdept = new SelectList(db.tbldept, "id", "name", tblstaff.fkdept);
            return View(tblstaff);
        }

        // GET: /staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstaff tblstaff = db.tblstaff.Find(id);
            if (tblstaff == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkdept = new SelectList(db.tbldept, "id", "name", tblstaff.fkdept);
            return View(tblstaff);
        }

        // POST: /staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,fkdept")] tblstaff tblstaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblstaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkdept = new SelectList(db.tbldept, "id", "name", tblstaff.fkdept);
            return View(tblstaff);
        }

        // GET: /staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstaff tblstaff = db.tblstaff.Find(id);
            if (tblstaff == null)
            {
                return HttpNotFound();
            }
            return View(tblstaff);
        }

        // POST: /staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblstaff tblstaff = db.tblstaff.Find(id);
            db.tblstaff.Remove(tblstaff);
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
