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
    public class EmployeeController : Controller
    {
        starEntities EMP = new starEntities(); 
        
        
        public ActionResult employee_edit()
        {
            
            return View(EMP.employe_Reg.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult delete_reg(int? id)
        {
            EMP.employe_Reg.Remove(EMP.employe_Reg.Find(id));
            EMP.SaveChanges();
            return RedirectToAction("employee_edit", "Employee");
        }
        [Authorize(Roles ="admin")]
        public ActionResult edit(int? id)
        {
            return View(EMP.employe_Reg.Find(id));
        }

        [HttpPost]
        [Authorize(Roles ="admin")]
        public ActionResult edit(int? id, employe_Reg e)
        {
            //var m = Path.Combine(Server.MapPath("~/EmpImages/"), Path.GetFileName(imgup.FileName));
            //imgup.SaveAs(m);

            var data = EMP.employe_Reg.Where(a => a.reg_id_code == id).FirstOrDefault();
            data.reg_name = e.reg_name;
            data.reg_role = e.reg_role;
            data.reg_depart = e.reg_depart; 
            data.reg_client = e.reg_client;
            data.reg_grade = e.reg_grade;
            data.reg_education = e.reg_education;
            data.reg_achieve = e.reg_achieve;
            data.reg_email = e.reg_email;
            data.reg_number = e.reg_number;
            data.reg_address = e.reg_address;
            data.reg_img = e.reg_img;
            EMP.SaveChanges();
            return RedirectToAction("employee_edit", "Employee");

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employe_Reg employe_Reg = EMP.employe_Reg.Find(id);
            if (employe_Reg == null)
            {
                return HttpNotFound();
            }
            return View(employe_Reg);
        }

        
        [Authorize(Roles ="admin")]
        public ActionResult add_employee()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles ="admin")]
        public ActionResult add_employee(employe_Reg a, HttpPostedFileBase img)
        {
            var data = Path.Combine(Server.MapPath("~/EmpImages/"), Path.GetFileName(img.FileName));
            img.SaveAs(data);
            a.reg_img = img.FileName;
            Session["img2"] = a.reg_img;
            EMP.employe_Reg.Add(a);
            EMP.SaveChanges();
            ModelState.Clear();
            return View();
        }

    }
}