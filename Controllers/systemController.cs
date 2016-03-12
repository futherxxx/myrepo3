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
    public class systemController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /system/
        public ActionResult Index()
        {
            var tblsystem = db.tblsystem.Include(t => t.tblsystem2).Include(t => t.tblvendor);
            return View(tblsystem.ToList());
        }

        // GET: /system/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblsystem tblsystem = db.tblsystem.Find(id);
            if (tblsystem == null)
            {
                return HttpNotFound();
            }
            return View(tblsystem);
        }

        // GET: /system/Create
        public ActionResult Create()
        {
            ViewBag.fksystemtype = new SelectList(db.tblsystem, "id", "name");
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name");
            return View();
        }

        // POST: /system/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,model,serialno,pno,processor,memory,hdd,dvdcd,operational,fkvendor,fksystemtype")] tblsystem tblsystem)
        {
            if (ModelState.IsValid)
            {
                db.tblsystem.Add(tblsystem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fksystemtype = new SelectList(db.tblsystem, "id", "name", tblsystem.fksystemtype);
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblsystem.fkvendor);
            return View(tblsystem);
        }

        // GET: /system/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblsystem tblsystem = db.tblsystem.Find(id);
            if (tblsystem == null)
            {
                return HttpNotFound();
            }
            ViewBag.fksystemtype = new SelectList(db.tblsystem, "id", "name", tblsystem.fksystemtype);
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblsystem.fkvendor);
            return View(tblsystem);
        }

        // POST: /system/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,model,serialno,pno,processor,memory,hdd,dvdcd,operational,fkvendor,fksystemtype")] tblsystem tblsystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblsystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fksystemtype = new SelectList(db.tblsystem, "id", "name", tblsystem.fksystemtype);
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblsystem.fkvendor);
            return View(tblsystem);
        }

        // GET: /system/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblsystem tblsystem = db.tblsystem.Find(id);
            if (tblsystem == null)
            {
                return HttpNotFound();
            }
            return View(tblsystem);
        }

        // POST: /system/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblsystem tblsystem = db.tblsystem.Find(id);
            db.tblsystem.Remove(tblsystem);
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
