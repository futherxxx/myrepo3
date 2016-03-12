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
    public class officeController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /office/
        public ActionResult Index()
        {
            var tbloffice = db.tbloffice.Include(t => t.tblvendor);
            return View(tbloffice.ToList());
        }

        // GET: /office/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbloffice tbloffice = db.tbloffice.Find(id);
            if (tbloffice == null)
            {
                return HttpNotFound();
            }
            return View(tbloffice);
        }

        // GET: /office/Create
        public ActionResult Create()
        {
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name");
            return View();
        }

        // POST: /office/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,version,fkvendor")] tbloffice tbloffice)
        {
            if (ModelState.IsValid)
            {
                db.tbloffice.Add(tbloffice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tbloffice.fkvendor);
            return View(tbloffice);
        }

        // GET: /office/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbloffice tbloffice = db.tbloffice.Find(id);
            if (tbloffice == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tbloffice.fkvendor);
            return View(tbloffice);
        }

        // POST: /office/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,version,fkvendor")] tbloffice tbloffice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbloffice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tbloffice.fkvendor);
            return View(tbloffice);
        }

        // GET: /office/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbloffice tbloffice = db.tbloffice.Find(id);
            if (tbloffice == null)
            {
                return HttpNotFound();
            }
            return View(tbloffice);
        }

        // POST: /office/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbloffice tbloffice = db.tbloffice.Find(id);
            db.tbloffice.Remove(tbloffice);
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
