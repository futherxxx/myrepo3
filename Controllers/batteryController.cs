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
    public class batteryController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /battery/
        public ActionResult Index()
        {
            var tblbattery = db.tblbattery.Include(t => t.tblvendor);
            return View(tblbattery.ToList());
        }

        // GET: /battery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblbattery tblbattery = db.tblbattery.Find(id);
            if (tblbattery == null)
            {
                return HttpNotFound();
            }
            return View(tblbattery);
        }

        // GET: /battery/Create
        public ActionResult Create()
        {
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name");
            return View();
        }

        // POST: /battery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,serialno,txtdesc,fkvendor")] tblbattery tblbattery)
        {
            if (ModelState.IsValid)
            {
                db.tblbattery.Add(tblbattery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblbattery.fkvendor);
            return View(tblbattery);
        }

        // GET: /battery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblbattery tblbattery = db.tblbattery.Find(id);
            if (tblbattery == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblbattery.fkvendor);
            return View(tblbattery);
        }

        // POST: /battery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,serialno,txtdesc,fkvendor")] tblbattery tblbattery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblbattery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblbattery.fkvendor);
            return View(tblbattery);
        }

        // GET: /battery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblbattery tblbattery = db.tblbattery.Find(id);
            if (tblbattery == null)
            {
                return HttpNotFound();
            }
            return View(tblbattery);
        }

        // POST: /battery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblbattery tblbattery = db.tblbattery.Find(id);
            db.tblbattery.Remove(tblbattery);
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
