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
    public class vendorController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /vendor/
        public ActionResult Index()
        {
            return View(db.tblvendor.ToList());
        }

        // GET: /vendor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblvendor tblvendor = db.tblvendor.Find(id);
            if (tblvendor == null)
            {
                return HttpNotFound();
            }
            return View(tblvendor);
        }

        // GET: /vendor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /vendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,address,email,phone")] tblvendor tblvendor)
        {
            if (ModelState.IsValid)
            {
                db.tblvendor.Add(tblvendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblvendor);
        }

        // GET: /vendor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblvendor tblvendor = db.tblvendor.Find(id);
            if (tblvendor == null)
            {
                return HttpNotFound();
            }
            return View(tblvendor);
        }

        // POST: /vendor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,address,email,phone")] tblvendor tblvendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblvendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblvendor);
        }

        // GET: /vendor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblvendor tblvendor = db.tblvendor.Find(id);
            if (tblvendor == null)
            {
                return HttpNotFound();
            }
            return View(tblvendor);
        }

        // POST: /vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblvendor tblvendor = db.tblvendor.Find(id);
            db.tblvendor.Remove(tblvendor);
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
