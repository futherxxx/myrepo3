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
    public class softwareController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /software/
        public ActionResult Index()
        {
            return View(db.tblsoftware.ToList());
        }

        // GET: /software/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblsoftware tblsoftware = db.tblsoftware.Find(id);
            if (tblsoftware == null)
            {
                return HttpNotFound();
            }
            return View(tblsoftware);
        }

        // GET: /software/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /software/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,serialno,osversion,officeversion")] tblsoftware tblsoftware)
        {
            if (ModelState.IsValid)
            {
                db.tblsoftware.Add(tblsoftware);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblsoftware);
        }

        // GET: /software/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblsoftware tblsoftware = db.tblsoftware.Find(id);
            if (tblsoftware == null)
            {
                return HttpNotFound();
            }
            return View(tblsoftware);
        }

        // POST: /software/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,serialno,osversion,officeversion")] tblsoftware tblsoftware)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblsoftware).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblsoftware);
        }

        // GET: /software/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblsoftware tblsoftware = db.tblsoftware.Find(id);
            if (tblsoftware == null)
            {
                return HttpNotFound();
            }
            return View(tblsoftware);
        }

        // POST: /software/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblsoftware tblsoftware = db.tblsoftware.Find(id);
            db.tblsoftware.Remove(tblsoftware);
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
