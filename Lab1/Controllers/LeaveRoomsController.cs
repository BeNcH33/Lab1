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
    public class LeaveRoomsController : Controller
    {
        private LeaveRoomsDBContext db = new LeaveRoomsDBContext();

        // GET: LeaveRooms
        public ActionResult Index()
        {
            return View(db.Rooms.ToList());
        }

        // GET: LeaveRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveRooms leaveRooms = db.Rooms.Find(id);
            if (leaveRooms == null)
            {
                return HttpNotFound();
            }
            return View(leaveRooms);
        }

        // GET: LeaveRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveRooms/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Номер комнаты,Номер этажа,Количество мест")] LeaveRooms leaveRooms)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(leaveRooms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leaveRooms);
        }

        // GET: LeaveRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveRooms leaveRooms = db.Rooms.Find(id);
            if (leaveRooms == null)
            {
                return HttpNotFound();
            }
            return View(leaveRooms);
        }

        // POST: LeaveRooms/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Номер комнаты,Номер этажа,Количество мест")] LeaveRooms leaveRooms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveRooms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leaveRooms);
        }

        // GET: LeaveRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveRooms leaveRooms = db.Rooms.Find(id);
            if (leaveRooms == null)
            {
                return HttpNotFound();
            }
            return View(leaveRooms);
        }

        // POST: LeaveRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveRooms leaveRooms = db.Rooms.Find(id);
            db.Rooms.Remove(leaveRooms);
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
