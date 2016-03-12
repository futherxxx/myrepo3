using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PCDetailsWeb.Models
{
    public class deptController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /dept/
        public ActionResult Index()
        {
            return View(db.tbldept.ToList());
        }

        // GET: /dept/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbldept tbldept = db.tbldept.Find(id);
            if (tbldept == null)
            {
                return HttpNotFound();
            }
            return View(tbldept);
        }

        // GET: /dept/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /dept/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name")] tbldept tbldept)
        {
            if (ModelState.IsValid)
            {
                db.tbldept.Add(tbldept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbldept);
        }

        // GET: /dept/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbldept tbldept = db.tbldept.Find(id);
            if (tbldept == null)
            {
                return HttpNotFound();
            }
            return View(tbldept);
        }

        // POST: /dept/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name")] tbldept tbldept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbldept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbldept);
        }

        // GET: /dept/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbldept tbldept = db.tbldept.Find(id);
            if (tbldept == null)
            {
                return HttpNotFound();
            }
            return View(tbldept);
        }

        // POST: /dept/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbldept tbldept = db.tbldept.Find(id);
            db.tbldept.Remove(tbldept);
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
