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
    public class warrantyController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /warranty/
        public ActionResult Index()
        {
            var tblwarranty = db.tblwarranty.Include(t => t.tblstatus).Include(t => t.tblsystem).Include(t => t.tblvendor);
            return View(tblwarranty.ToList());
        }

        // GET: /warranty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblwarranty tblwarranty = db.tblwarranty.Find(id);
            if (tblwarranty == null)
            {
                return HttpNotFound();
            }
            return View(tblwarranty);
        }

        // GET: /warranty/Create
        public ActionResult Create()
        {
            ViewBag.warrantystatus = new SelectList(db.tblstatus, "id", "name");
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name");
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name");
            return View();
        }

        // POST: /warranty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,fksystem,assignedto,configdate,preparedby,dateofpurchase,warrantystatus,warrantyexpiration,fkvendor")] tblwarranty tblwarranty)
        {
            if (ModelState.IsValid)
            {
                db.tblwarranty.Add(tblwarranty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.warrantystatus = new SelectList(db.tblstatus, "id", "name", tblwarranty.warrantystatus);
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name", tblwarranty.fksystem);
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblwarranty.fkvendor);
            return View(tblwarranty);
        }

        // GET: /warranty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblwarranty tblwarranty = db.tblwarranty.Find(id);
            if (tblwarranty == null)
            {
                return HttpNotFound();
            }
            ViewBag.warrantystatus = new SelectList(db.tblstatus, "id", "name", tblwarranty.warrantystatus);
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name", tblwarranty.fksystem);
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblwarranty.fkvendor);
            return View(tblwarranty);
        }

        // POST: /warranty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,fksystem,assignedto,configdate,preparedby,dateofpurchase,warrantystatus,warrantyexpiration,fkvendor")] tblwarranty tblwarranty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblwarranty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.warrantystatus = new SelectList(db.tblstatus, "id", "name", tblwarranty.warrantystatus);
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name", tblwarranty.fksystem);
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblwarranty.fkvendor);
            return View(tblwarranty);
        }

        // GET: /warranty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblwarranty tblwarranty = db.tblwarranty.Find(id);
            if (tblwarranty == null)
            {
                return HttpNotFound();
            }
            return View(tblwarranty);
        }

        // POST: /warranty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblwarranty tblwarranty = db.tblwarranty.Find(id);
            db.tblwarranty.Remove(tblwarranty);
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
