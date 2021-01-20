using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project.Models;
using System.IO;
using System.Web.Security;

namespace project.Controllers
{
    [Authorize]
    public class servicesController : Controller
    {
        public starEntities db = new starEntities();

        [Authorize]
        public ActionResult Index()
        {
            var services = db.services.Include(s => s.category_T);
            return View(services.ToList());
        }

        // GET: services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            service service = db.services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.ser_fk_cat = new SelectList(db.category_T, "cat_id", "cat_title");
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ser_id,ser_title,ser_discrip,ser_img,ser_fk_cat,ser_img_2,ser_discrip_2")] service service , HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                var pro = Path.Combine(Server.MapPath("~/Servicesimages/"), Path.GetFileName(img.FileName));
                img.SaveAs(pro);
                service.ser_img = img.FileName;

                db.services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ser_fk_cat = new SelectList(db.category_T, "cat_id", "cat_title", service.ser_fk_cat);
            return View(service);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            service service = db.services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.ser_fk_cat = new SelectList(db.category_T, "cat_id", "cat_title", service.ser_fk_cat);
            return View(service);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ser_id,ser_title,ser_discrip,ser_img,ser_fk_cat,ser_img_2,ser_discrip_2")] service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ser_fk_cat = new SelectList(db.category_T, "cat_id", "cat_title", service.ser_fk_cat);
            return View(service);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            service service = db.services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }
        [Authorize(Roles = "admin")]
        // POST: services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service service = db.services.Find(id);
            db.services.Remove(service);
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
