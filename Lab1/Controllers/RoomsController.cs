using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class RoomsController : Controller
    {
        private RoomsDBContext db = new RoomsDBContext();

        // GET: Rooms
        public ActionResult Index()
        {
            return View(db.Rooms.ToList());
        }

        // GET: Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = db.Rooms.Find(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            return View(rooms);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,floor,NameRoom")] Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(rooms);
                db.SaveChanges();

                HttpStatusCode code = SendToAPI(rooms);
                switch (code)
                {
                    case HttpStatusCode.NoContent:
                        {
                            return RedirectToAction("Index");
                        }
                    default:
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }
                }

            }

            return View(rooms);
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = db.Rooms.Find(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            return View(rooms);
        }

        // POST: Rooms/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,floor,NameRoom")] Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rooms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rooms);
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = db.Rooms.Find(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            return View(rooms);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rooms rooms = db.Rooms.Find(id);
            db.Rooms.Remove(rooms);
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


        public ActionResult LoadFromAPI()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:5001/Room");
            request.Accept = "application/xml";
            WebResponse response = request.GetResponse();
            XmlDocument doc = new XmlDocument();
            doc.Load(response.GetResponseStream());
            XmlElement root = doc.DocumentElement;
            foreach (XmlElement RoomsNode in root)
            {
                int id = Convert.ToInt32(RoomsNode["ID"].InnerText);
                Rooms rooms = db.Rooms.Find(id);
                if (rooms == null)
                {
                    Rooms newRooms = new Rooms()
                    {
                        floor = Convert.ToInt32(RoomsNode["floor"].InnerText),
                        NameRoom = RoomsNode["NameRoom"].InnerText,
                        NumberRoom = Convert.ToInt32(RoomsNode["NumberRoom"].InnerText),

                    };
                    db.Rooms.Add(newRooms);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private XmlElement PackStudentToXml(XmlDocument doc, Rooms rooms)
        {
            XmlElement roomsNode = doc.CreateElement("Rooms");
            XmlElement IdNode = doc.CreateElement("Id");
            IdNode.InnerText = rooms.ID.ToString();
            roomsNode.AppendChild(IdNode);

            XmlElement floorNode = doc.CreateElement("floor");
            floorNode.InnerText = Convert.ToString(rooms.floor);
            roomsNode.AppendChild(floorNode);

            XmlElement GroupNode = doc.CreateElement("NameRoom");
            GroupNode.InnerText = rooms.NameRoom;
            roomsNode.AppendChild(GroupNode);

            XmlElement PhoneNoNode = doc.CreateElement("PhoneNo");
            PhoneNoNode.InnerText = Convert.ToString(rooms.NumberRoom);
            roomsNode.AppendChild(PhoneNoNode);

            return roomsNode;
        }

        private HttpStatusCode SendToAPI(Rooms rooms)
        {
            //формируем xml документ
            XmlDocument doc = new XmlDocument();
            doc.CreateXmlDeclaration("1.0", "utf-8", "no");
            XmlElement studentNode = PackStudentToXml(doc, rooms);
            doc.AppendChild(studentNode);
            //получаем строку в формате XML
            string xml = doc.OuterXml;
            //преобразуем строку в массив байт
            byte[] byteArray = Encoding.UTF8.GetBytes(xml);
            //создаем http запрос, указываем метод и тип содержимого
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:5001/Room");
            request.Method = "POST";
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = byteArray.Length;

            //в поток (в тело) запроса записываем подготовленный массив байт
            var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);
            reqStream.Close();

            //отправляем запрос и получаем ответ
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response.StatusCode;
        }
    }
}
