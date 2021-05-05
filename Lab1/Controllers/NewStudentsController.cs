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
    public class NewStudentsController : Controller
    {
        private StudentDBContext db = new StudentDBContext();

        // GET: NewStudents
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: NewStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewStudent newStudent = db.Students.Find(id);
            if (newStudent == null)
            {
                return HttpNotFound();
            }
            return View(newStudent);
        }

        // GET: NewStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewStudents/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Surname,Otch,PasportSer,PasportNumber,ZachetNumber,Sex,Birthday,Town")] NewStudent newStudent)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(newStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newStudent);
        }

        // GET: NewStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewStudent newStudent = db.Students.Find(id);
            if (newStudent == null)
            {
                return HttpNotFound();
            }
            return View(newStudent);
        }

        // POST: NewStudents/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Surname,Otch,PasportSer,PasportNumber,ZachetNumber,Sex,Birthday,Town")] NewStudent newStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newStudent);
        }

        // GET: NewStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewStudent newStudent = db.Students.Find(id);
            if (newStudent == null)
            {
                return HttpNotFound();
            }
            return View(newStudent);
        }

        // POST: NewStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewStudent newStudent = db.Students.Find(id);
            db.Students.Remove(newStudent);
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
