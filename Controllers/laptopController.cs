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
    public class laptopController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /laptop/
        public ActionResult Index()
        {
            var tbllaptop = db.tbllaptop.Include(t => t.tblbattery).Include(t => t.tblsystem);
            return View(tbllaptop.ToList());
        }

        // GET: /laptop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbllaptop tbllaptop = db.tbllaptop.Find(id);
            if (tbllaptop == null)
            {
                return HttpNotFound();
            }
            return View(tbllaptop);
        }

        // GET: /laptop/Create
        public ActionResult Create()
        {
            ViewBag.fkbattery = new SelectList(db.tblbattery, "id", "name");
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name");
            return View();
        }

        // POST: /laptop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,fkbattery,fksystem")] tbllaptop tbllaptop)
        {
            if (ModelState.IsValid)
            {
                db.tbllaptop.Add(tbllaptop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkbattery = new SelectList(db.tblbattery, "id", "name", tbllaptop.fkbattery);
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name", tbllaptop.fksystem);
            return View(tbllaptop);
        }

        // GET: /laptop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbllaptop tbllaptop = db.tbllaptop.Find(id);
            if (tbllaptop == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkbattery = new SelectList(db.tblbattery, "id", "name", tbllaptop.fkbattery);
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name", tbllaptop.fksystem);
            return View(tbllaptop);
        }

        // POST: /laptop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,fkbattery,fksystem")] tbllaptop tbllaptop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbllaptop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkbattery = new SelectList(db.tblbattery, "id", "name", tbllaptop.fkbattery);
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name", tbllaptop.fksystem);
            return View(tbllaptop);
        }

        // GET: /laptop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbllaptop tbllaptop = db.tbllaptop.Find(id);
            if (tbllaptop == null)
            {
                return HttpNotFound();
            }
            return View(tbllaptop);
        }

        // POST: /laptop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbllaptop tbllaptop = db.tbllaptop.Find(id);
            db.tbllaptop.Remove(tbllaptop);
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
