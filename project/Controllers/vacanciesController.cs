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
    public class vacanciesController : Controller
    {
        
        public starEntities db = new starEntities();

        
        public ActionResult Index()
        {
            return View(db.vacancies.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacancy vacancy = db.vacancies.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "vac_id,vac_title,vac_discrip_1,vac_discrip_2,vac_last_date,vac_image")] vacancy vacancy , HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                var data = Path.Combine(Server.MapPath("~/vacancyimages/"), Path.GetFileName(img.FileName));
                img.SaveAs(data);
                vacancy.vac_image = img.FileName;

                db.vacancies.Add(vacancy);
                db.SaveChanges();
                ViewBag.vacancy = "Vacancy Successfully Done";
                return RedirectToAction("Index");
            }

            return View(vacancy);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacancy vacancy = db.vacancies.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "vac_id,vac_title,vac_discrip_1,vac_discrip_2,vac_last_date,vac_image")] vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacancy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacancy);
        }

        [Authorize(Roles ="admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacancy vacancy = db.vacancies.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        // POST: vacancies/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vacancy vacancy = db.vacancies.Find(id);
            db.vacancies.Remove(vacancy);
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
        
        public ActionResult job_view()
        {
            return View(db.jobs.ToList());
        }
        [Authorize(Roles ="admin")]
        public ActionResult delete_job(int? id)
        {
            db.jobs.Remove(db.jobs.Find(id));
            db.SaveChanges();
            return RedirectToAction("job_view", "vacancies");
        }

        
        
        public ActionResult contact_view()
        {
            return View(db.contacts.ToList());
        }
        [Authorize(Roles ="admin")]
        public ActionResult delete_contact(int? id)
        {
            db.contacts.Remove(db.contacts.Find(id));
            db.SaveChanges();
            return RedirectToAction("contact_view", "vacancies");
        }

        

    }
}
