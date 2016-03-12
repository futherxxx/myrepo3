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
    public class keyboardController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /keyboard/
        public ActionResult Index()
        {
            var tblkeyboard = db.tblkeyboard.Include(t => t.tblvendor);
            return View(tblkeyboard.ToList());
        }

        // GET: /keyboard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblkeyboard tblkeyboard = db.tblkeyboard.Find(id);
            if (tblkeyboard == null)
            {
                return HttpNotFound();
            }
            return View(tblkeyboard);
        }

        // GET: /keyboard/Create
        public ActionResult Create()
        {
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name");
            return View();
        }

        // POST: /keyboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,serialno,version,fkvendor")] tblkeyboard tblkeyboard)
        {
            if (ModelState.IsValid)
            {
                db.tblkeyboard.Add(tblkeyboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblkeyboard.fkvendor);
            return View(tblkeyboard);
        }

        // GET: /keyboard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblkeyboard tblkeyboard = db.tblkeyboard.Find(id);
            if (tblkeyboard == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblkeyboard.fkvendor);
            return View(tblkeyboard);
        }

        // POST: /keyboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,serialno,version,fkvendor")] tblkeyboard tblkeyboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblkeyboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblkeyboard.fkvendor);
            return View(tblkeyboard);
        }

        // GET: /keyboard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblkeyboard tblkeyboard = db.tblkeyboard.Find(id);
            if (tblkeyboard == null)
            {
                return HttpNotFound();
            }
            return View(tblkeyboard);
        }

        // POST: /keyboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblkeyboard tblkeyboard = db.tblkeyboard.Find(id);
            db.tblkeyboard.Remove(tblkeyboard);
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
