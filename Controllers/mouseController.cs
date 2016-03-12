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
    public class mouseController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /mouse/
        public ActionResult Index()
        {
            var tblmouse = db.tblmouse.Include(t => t.tblvendor);
            return View(tblmouse.ToList());
        }

        // GET: /mouse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblmouse tblmouse = db.tblmouse.Find(id);
            if (tblmouse == null)
            {
                return HttpNotFound();
            }
            return View(tblmouse);
        }

        // GET: /mouse/Create
        public ActionResult Create()
        {
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name");
            return View();
        }

        // POST: /mouse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,serialno,version,fkvendor")] tblmouse tblmouse)
        {
            if (ModelState.IsValid)
            {
                db.tblmouse.Add(tblmouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblmouse.fkvendor);
            return View(tblmouse);
        }

        // GET: /mouse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblmouse tblmouse = db.tblmouse.Find(id);
            if (tblmouse == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblmouse.fkvendor);
            return View(tblmouse);
        }

        // POST: /mouse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,serialno,version,fkvendor")] tblmouse tblmouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblmouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblmouse.fkvendor);
            return View(tblmouse);
        }

        // GET: /mouse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblmouse tblmouse = db.tblmouse.Find(id);
            if (tblmouse == null)
            {
                return HttpNotFound();
            }
            return View(tblmouse);
        }

        // POST: /mouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblmouse tblmouse = db.tblmouse.Find(id);
            db.tblmouse.Remove(tblmouse);
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
