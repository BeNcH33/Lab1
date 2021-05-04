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
    public class ViolationContentsController : Controller
    {
        private ViolationDBContext db = new ViolationDBContext();

        // GET: ViolationContents
        public ActionResult Index()
        {
            return View(db.ViolationContents.ToList());
        }

        // GET: ViolationContents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViolationContent violationContent = db.ViolationContents.Find(id);
            if (violationContent == null)
            {
                return HttpNotFound();
            }
            return View(violationContent);
        }

        // GET: ViolationContents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViolationContents/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,description,Penalties")] ViolationContent violationContent)
        {
            if (ModelState.IsValid)
            {
                db.ViolationContents.Add(violationContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(violationContent);
        }

        // GET: ViolationContents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViolationContent violationContent = db.ViolationContents.Find(id);
            if (violationContent == null)
            {
                return HttpNotFound();
            }
            return View(violationContent);
        }

        // POST: ViolationContents/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,description,Penalties")] ViolationContent violationContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(violationContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(violationContent);
        }

        // GET: ViolationContents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViolationContent violationContent = db.ViolationContents.Find(id);
            if (violationContent == null)
            {
                return HttpNotFound();
            }
            return View(violationContent);
        }

        // POST: ViolationContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViolationContent violationContent = db.ViolationContents.Find(id);
            db.ViolationContents.Remove(violationContent);
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
