using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class ViolationsController : Controller
    {
        private RoomsDBContext db = new RoomsDBContext();

        // GET: Violations
        public ActionResult Index()
        {
            return View(db.Violations.ToList());
        }

        // GET: Violations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Violation violation = db.Violations.Find(id);
            if (violation == null)
            {
                return HttpNotFound();
            }
            return View(violation);
        }

        // GET: Violations/Create
        public ActionResult Create(int idStudent, int idViolation)
        {
            ViewBag.idStudent = idStudent;
            ViewBag.idViolation = idViolation;
            return View();
        }

        // POST: Violations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,category,Date,IdStudent,IdViolation")] Violation violation)
        {
            if (ModelState.IsValid)
            {
                db.Violations.Add(violation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(violation);
        }

        // GET: Violations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Violation violation = db.Violations.Find(id);
            if (violation == null)
            {
                return HttpNotFound();
            }
            return View(violation);
        }

        // POST: Violations/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,category,Date")] Violation violation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(violation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(violation);
        }

        // GET: Violations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Violation violation = db.Violations.Find(id);
            if (violation == null)
            {
                return HttpNotFound();
            }
            return View(violation);
        }

        // POST: Violations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Violation violation = db.Violations.Find(id);
            db.Violations.Remove(violation);
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
