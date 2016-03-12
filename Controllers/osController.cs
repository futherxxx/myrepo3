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
    public class osController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /os/
        public ActionResult Index()
        {
            var tblos = db.tblos.Include(t => t.tblvendor);
            return View(tblos.ToList());
        }

        // GET: /os/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblos tblos = db.tblos.Find(id);
            if (tblos == null)
            {
                return HttpNotFound();
            }
            return View(tblos);
        }

        // GET: /os/Create
        public ActionResult Create()
        {
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name");
            return View();
        }

        // POST: /os/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,version,fkvendor")] tblos tblos)
        {
            if (ModelState.IsValid)
            {
                db.tblos.Add(tblos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblos.fkvendor);
            return View(tblos);
        }

        // GET: /os/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblos tblos = db.tblos.Find(id);
            if (tblos == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblos.fkvendor);
            return View(tblos);
        }

        // POST: /os/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,version,fkvendor")] tblos tblos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkvendor = new SelectList(db.tblvendor, "id", "name", tblos.fkvendor);
            return View(tblos);
        }

        // GET: /os/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblos tblos = db.tblos.Find(id);
            if (tblos == null)
            {
                return HttpNotFound();
            }
            return View(tblos);
        }

        // POST: /os/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblos tblos = db.tblos.Find(id);
            db.tblos.Remove(tblos);
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
