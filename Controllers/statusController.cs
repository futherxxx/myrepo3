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
    public class statusController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /status/
        public ActionResult Index()
        {
            return View(db.tblstatus.ToList());
        }

        // GET: /status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstatus tblstatus = db.tblstatus.Find(id);
            if (tblstatus == null)
            {
                return HttpNotFound();
            }
            return View(tblstatus);
        }

        // GET: /status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,description")] tblstatus tblstatus)
        {
            if (ModelState.IsValid)
            {
                db.tblstatus.Add(tblstatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblstatus);
        }

        // GET: /status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstatus tblstatus = db.tblstatus.Find(id);
            if (tblstatus == null)
            {
                return HttpNotFound();
            }
            return View(tblstatus);
        }

        // POST: /status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,description")] tblstatus tblstatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblstatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblstatus);
        }

        // GET: /status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstatus tblstatus = db.tblstatus.Find(id);
            if (tblstatus == null)
            {
                return HttpNotFound();
            }
            return View(tblstatus);
        }

        // POST: /status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblstatus tblstatus = db.tblstatus.Find(id);
            db.tblstatus.Remove(tblstatus);
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
