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
    public class desktopController : Controller
    {
        private PCDetailsModel db = new PCDetailsModel();

        // GET: /desktop/
        public ActionResult Index()
        {
            var tbldesktop = db.tbldesktop.Include(t => t.tblkeyboard).Include(t => t.tblmonitor).Include(t => t.tblmouse).Include(t => t.tblpowerpack).Include(t => t.tblsystem);
            return View(tbldesktop.ToList());
        }

        // GET: /desktop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbldesktop tbldesktop = db.tbldesktop.Find(id);
            if (tbldesktop == null)
            {
                return HttpNotFound();
            }
            return View(tbldesktop);
        }

        // GET: /desktop/Create
        public ActionResult Create()
        {
            ViewBag.fkkeyboard = new SelectList(db.tblkeyboard, "id", "name");
            ViewBag.fkmonitor = new SelectList(db.tblmonitor, "id", "name");
            ViewBag.fkmouse = new SelectList(db.tblmouse, "id", "name");
            ViewBag.fkpowerpack = new SelectList(db.tblpowerpack, "id", "name");
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name");
            return View();
        }

        // POST: /desktop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,fksystem,fkmonitor,fkkeyboard,fkmouse,fkpowerpack")] tbldesktop tbldesktop)
        {
            if (ModelState.IsValid)
            {
                db.tbldesktop.Add(tbldesktop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkkeyboard = new SelectList(db.tblkeyboard, "id", "name", tbldesktop.fkkeyboard);
            ViewBag.fkmonitor = new SelectList(db.tblmonitor, "id", "name", tbldesktop.fkmonitor);
            ViewBag.fkmouse = new SelectList(db.tblmouse, "id", "name", tbldesktop.fkmouse);
            ViewBag.fkpowerpack = new SelectList(db.tblpowerpack, "id", "name", tbldesktop.fkpowerpack);
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name", tbldesktop.fksystem);
            return View(tbldesktop);
        }

        // GET: /desktop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbldesktop tbldesktop = db.tbldesktop.Find(id);
            if (tbldesktop == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkkeyboard = new SelectList(db.tblkeyboard, "id", "name", tbldesktop.fkkeyboard);
            ViewBag.fkmonitor = new SelectList(db.tblmonitor, "id", "name", tbldesktop.fkmonitor);
            ViewBag.fkmouse = new SelectList(db.tblmouse, "id", "name", tbldesktop.fkmouse);
            ViewBag.fkpowerpack = new SelectList(db.tblpowerpack, "id", "name", tbldesktop.fkpowerpack);
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name", tbldesktop.fksystem);
            return View(tbldesktop);
        }

        // POST: /desktop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,fksystem,fkmonitor,fkkeyboard,fkmouse,fkpowerpack")] tbldesktop tbldesktop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbldesktop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkkeyboard = new SelectList(db.tblkeyboard, "id", "name", tbldesktop.fkkeyboard);
            ViewBag.fkmonitor = new SelectList(db.tblmonitor, "id", "name", tbldesktop.fkmonitor);
            ViewBag.fkmouse = new SelectList(db.tblmouse, "id", "name", tbldesktop.fkmouse);
            ViewBag.fkpowerpack = new SelectList(db.tblpowerpack, "id", "name", tbldesktop.fkpowerpack);
            ViewBag.fksystem = new SelectList(db.tblsystem, "id", "name", tbldesktop.fksystem);
            return View(tbldesktop);
        }

        // GET: /desktop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbldesktop tbldesktop = db.tbldesktop.Find(id);
            if (tbldesktop == null)
            {
                return HttpNotFound();
            }
            return View(tbldesktop);
        }

        // POST: /desktop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbldesktop tbldesktop = db.tbldesktop.Find(id);
            db.tbldesktop.Remove(tbldesktop);
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
