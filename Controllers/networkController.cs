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
    public class networkController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /network/
        public ActionResult Index()
        {
            var tblnetwork = db.tblnetwork.Include(t => t.tblsystem);
            return View(tblnetwork.ToList());
        }

        // GET: /network/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblnetwork tblnetwork = db.tblnetwork.Find(id);
            if (tblnetwork == null)
            {
                return HttpNotFound();
            }
            return View(tblnetwork);
        }

        // GET: /network/Create
        public ActionResult Create()
        {
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name");
            return View();
        }

        // POST: /network/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,fksystem,macaddress")] tblnetwork tblnetwork)
        {
            if (ModelState.IsValid)
            {
                db.tblnetwork.Add(tblnetwork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name", tblnetwork.fksystem);
            return View(tblnetwork);
        }

        // GET: /network/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblnetwork tblnetwork = db.tblnetwork.Find(id);
            if (tblnetwork == null)
            {
                return HttpNotFound();
            }
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name", tblnetwork.fksystem);
            return View(tblnetwork);
        }

        // POST: /network/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,fksystem,macaddress")] tblnetwork tblnetwork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblnetwork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name", tblnetwork.fksystem);
            return View(tblnetwork);
        }

        // GET: /network/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblnetwork tblnetwork = db.tblnetwork.Find(id);
            if (tblnetwork == null)
            {
                return HttpNotFound();
            }
            return View(tblnetwork);
        }

        // POST: /network/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblnetwork tblnetwork = db.tblnetwork.Find(id);
            db.tblnetwork.Remove(tblnetwork);
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
