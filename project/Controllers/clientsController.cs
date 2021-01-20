using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project.Models;
using System.Web.Security;

namespace project.Controllers
{
    [Authorize]
    public class clientsController : Controller
    {
        public starEntities db = new starEntities();

        // GET: clients
        public ActionResult Index()
        {
            var clients = db.clients.Include(c => c.category_T).Include(c => c.service);
            return View(clients.ToList());
        }

        // GET: clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = db.clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [Authorize(Roles ="admin")]
        public ActionResult Create()
        {
            ViewBag.client_fk_Cat = new SelectList(db.category_T, "cat_id", "cat_title");
            ViewBag.client_fk_ser = new SelectList(db.services, "ser_id", "ser_title");
            return View();
        }

        [Authorize(Roles ="admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "client_id,client_name,client_email,client_fk_Cat,client_fk_ser,client_msg")] client client)
        {
            if (ModelState.IsValid)
            {
                db.clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client_fk_Cat = new SelectList(db.category_T, "cat_id", "cat_title", client.client_fk_Cat);
            ViewBag.client_fk_ser = new SelectList(db.services, "ser_id", "ser_title", client.client_fk_ser);
            return View(client);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = db.clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.client_fk_Cat = new SelectList(db.category_T, "cat_id", "cat_title", client.client_fk_Cat);
            ViewBag.client_fk_ser = new SelectList(db.services, "ser_id", "ser_title", client.client_fk_ser);
            return View(client);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "client_id,client_name,client_email,client_fk_Cat,client_fk_ser,client_msg")] client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.client_fk_Cat = new SelectList(db.category_T, "cat_id", "cat_title", client.client_fk_Cat);
            ViewBag.client_fk_ser = new SelectList(db.services, "ser_id", "ser_title", client.client_fk_ser);
            return View(client);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = db.clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            client client = db.clients.Find(id);
            db.clients.Remove(client);
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
