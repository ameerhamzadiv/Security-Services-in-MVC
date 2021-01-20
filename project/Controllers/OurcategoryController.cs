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
    public class OurcategoryController : Controller
    {
        public starEntities db = new starEntities();

        
        public ActionResult Index()
        {
            return View(db.category_T.ToList());
        }

        // GET: Ourcategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category_T category_T = db.category_T.Find(id);
            if (category_T == null)
            {
                return HttpNotFound();
            }
            return View(category_T);
        }

        
        [Authorize(Roles ="admin")]
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category_T category_T = db.category_T.Find(id);
            if (category_T == null)
            {
                return HttpNotFound();
            }
            return View(category_T);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="admin")]
        public ActionResult Edit([Bind(Include = "cat_id,cat_title,cat_discrip")] category_T category_T)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_T).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category_T);
        }
        [Authorize(Roles = "admin")]
        // GET: Ourcategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category_T category_T = db.category_T.Find(id);
            if (category_T == null)
            {
                return HttpNotFound();
            }
            return View(category_T);
        }

        // POST: Ourcategory/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            category_T category_T = db.category_T.Find(id);
            db.category_T.Remove(category_T);
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
