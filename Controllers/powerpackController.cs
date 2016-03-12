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
    public class powerpackController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /powerpack/
        public ActionResult Index()
        {
            return View(db.tblpowerpack.ToList());
        }

        // GET: /powerpack/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblpowerpack tblpowerpack = db.tblpowerpack.Find(id);
            if (tblpowerpack == null)
            {
                return HttpNotFound();
            }
            return View(tblpowerpack);
        }

        // GET: /powerpack/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /powerpack/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,serialno,txtdesc")] tblpowerpack tblpowerpack)
        {
            if (ModelState.IsValid)
            {
                db.tblpowerpack.Add(tblpowerpack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblpowerpack);
        }

        // GET: /powerpack/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblpowerpack tblpowerpack = db.tblpowerpack.Find(id);
            if (tblpowerpack == null)
            {
                return HttpNotFound();
            }
            return View(tblpowerpack);
        }

        // POST: /powerpack/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,serialno,txtdesc")] tblpowerpack tblpowerpack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblpowerpack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblpowerpack);
        }

        // GET: /powerpack/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblpowerpack tblpowerpack = db.tblpowerpack.Find(id);
            if (tblpowerpack == null)
            {
                return HttpNotFound();
            }
            return View(tblpowerpack);
        }

        // POST: /powerpack/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblpowerpack tblpowerpack = db.tblpowerpack.Find(id);
            db.tblpowerpack.Remove(tblpowerpack);
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
