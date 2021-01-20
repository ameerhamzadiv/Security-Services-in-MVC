using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;
using System.Web.Security;

namespace project.Controllers
{
    [Authorize]
    public class backentController : Controller
    {
        starEntities reg = new starEntities();
        // GET: backent
        
        public ActionResult dashboard()
        {
            if (Session["name"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "main");
            }
            
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();

            Session["name"] = null;
            Session["img"] = null;
            Session["role"] = null;
            Session["client"] = null;
            Session["grade"] = null;
            Session["achievement"] = null;
            Session["email"] = null;
            Session["number"] = null;
            Session["department"] = null;
            Session["password"] = null;
            Session["code"] = null;
            Session["address"] = null;
            Session["education"] = null;
            return RedirectToAction("login", "main");
        }

        public ActionResult profile()
        {
            return View();
        }

        
    }


}