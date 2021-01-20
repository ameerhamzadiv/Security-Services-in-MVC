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
    public class PKGsController : Controller
    {
        private starEntities db = new starEntities();

        
        public ActionResult Index()
        {
            return View(db.PKGs.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PKG pKG = db.PKGs.Find(id);
            if (pKG == null)
            {
                return HttpNotFound();
            }
            return View(pKG);
        }

        [Authorize(Roles ="admin")]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="admin")]
        public ActionResult Create([Bind(Include = "P_id,p_title,p_price,p_1,p_2,p_3,p_4,p_5,p_6")] PKG pKG)
        {
            if (ModelState.IsValid)
            {
                db.PKGs.Add(pKG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pKG);
        }

        [Authorize(Roles ="admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PKG pKG = db.PKGs.Find(id);
            if (pKG == null)
            {
                return HttpNotFound();
            }
            return View(pKG);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "P_id,p_title,p_price,p_1,p_2,p_3,p_4,p_5,p_6")] PKG pKG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pKG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pKG);
        }

        [Authorize(Roles ="admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PKG pKG = db.PKGs.Find(id);
            if (pKG == null)
            {
                return HttpNotFound();
            }
            return View(pKG);
        }
        [Authorize(Roles = "admin")]  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PKG pKG = db.PKGs.Find(id);
            db.PKGs.Remove(pKG);
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
