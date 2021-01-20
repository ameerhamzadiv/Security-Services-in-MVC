using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;
using System.IO;
using System.Net;
using System.Web.Security;

namespace project.Controllers
{
    [Authorize]
    public class OurservicesController : Controller
    {
        starEntities reg = new starEntities();
        
        [Authorize(Roles ="admin")]
        public ActionResult Categorys()
        {
            
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Categorys(category_T c)
        {
            
                reg.category_T.Add(c);
                reg.SaveChanges();
                ModelState.Clear();
                return View();
           
        }
        

        


        
    }
}