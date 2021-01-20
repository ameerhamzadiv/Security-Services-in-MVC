using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;
using System.Web.Security;
using System.IO;

  
namespace project.Controllers
{

    public class mainController : Controller
    {
        starEntities reg = new starEntities();
        // GET: main
       
        public ActionResult home()
        {
            return View(reg.category_T.OrderByDescending(o => o.cat_id).ToList());
        }

        public ActionResult about()
        {
            return View();
        }


        public ActionResult all_service()
        {
            return View(reg.category_T.OrderByDescending(o => o.cat_id).ToList());
        }

       

        public ActionResult physical_services(int? id)
        {



            return View(reg.services.Where(i => i.ser_fk_cat == id).OrderByDescending(o => o.ser_id).ToList());
        }

      

        public ActionResult careers_us()
        {
            return View(reg.vacancies.OrderByDescending(c => c.vac_id).ToList());
        }

        public ActionResult vac_btn(int? id)
        {
            vacancy v = reg.vacancies.Where(m => m.vac_id == id).ToList().FirstOrDefault();
            return View(v);
        }

        public ActionResult job_form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult job_form(job j)
        {

            reg.jobs.Add(j);
            var sa = reg.SaveChanges();
            if (sa != 0)
            {
                ViewBag.vdone = "Job Request " +
                    "Our experts will reply you very soon";
                return RedirectToAction("careers_us");
            }
            else
            {
                ViewBag.verror = "Not Send Please Check Again";
            }

            return View();
        }

        public ActionResult careers()
        {
            return View();
        }

       

        public ActionResult read_more(int? id)
        {
          
            service p = reg.services.Where(m => m.ser_id == id).SingleOrDefault();
            return View(p);
        }


        public ActionResult client()
        {
            ViewBag.client_fk_cat = new SelectList(reg.category_T, "cat_id", "cat_title");
            ViewBag.client_fk_ser = new SelectList(reg.services, "ser_id", "ser_title");
            return View();
        }
        [HttpPost]
        public ActionResult client(client cl )
        {

            ViewBag.client_fk_cat = new SelectList(reg.category_T, "cat_id", "cat_title",cl.client_fk_Cat);
            ViewBag.client_fk_ser = new SelectList(reg.services, "ser_id", "ser_title",cl.client_fk_ser);
            reg.clients.Add(cl);
            var c = reg.SaveChanges();
            if (c != 0)
            {
                ViewBag.ordersend = "Your Messaege Successfully Send";
                ViewBag.ordersend2 = "Our Employee Message You Soon, Thank You";
                ModelState.Clear();
            }
            else
            {
                ViewBag.errorsend = "Your Message Not Send Please Fill Again";

            }
            return View();
            
            
        }


        public ActionResult Pkgs()
        {
            return View(reg.PKGs.OrderByDescending(p => p.P_id).ToList());
        }

       

        public ActionResult gallery()
        {
            return View();
        }

        


        public ActionResult member_profile()
        {
            return View();
        }

        public ActionResult member_profile_2()
        {
            return View();
        }

        public ActionResult member_profile_3()
        {
            return View();
        }

        public ActionResult member_profile_4()
        {
            return View();
        }

        

        public ActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult contact(contact c)
        {
            reg.contacts.Add(c);
            var s =  reg.SaveChanges();
            if (s != 0)
            {
                ViewBag.cdone = "Successfully Send";
                ViewBag.cdonem = "Our experts will reply you very soon";
                ModelState.Clear();
            }
            else
            {
                ViewBag.errorc = "Same Problem Please Fill Again";
                
            }
            return View();
        }

       

        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult login(employe_Reg l)
        {
            var b = reg.employe_Reg.Where(a =>a.reg_email== l.reg_email && a.password == l.password).FirstOrDefault();
            if (b != null)
            {
                FormsAuthentication.SetAuthCookie(l.reg_email, false);
               
                Session["name"] = b.reg_name;
                Session["img"] = b.reg_img;
                Session["role"] = b.reg_role;
                Session["client"] = b.reg_client;
                Session["grade"] = b.reg_grade;
                Session["achievement"] = b.reg_achieve;
                Session["email"] = b.reg_email;
                Session["number"] = b.reg_number;
                Session["department"] = b.reg_depart;
                Session["password"] = b.password;
                Session["code"] = b.code;
                Session["address"] = b.reg_address;
                Session["education"] = b.reg_education;
                return RedirectToAction("dashboard", "backent");
            }
            else

            {
                ViewBag.login = "Please Check Your Email Or Password";
               
            }
            return View();
        }

        public ActionResult chairman()
        {
            return View();
        }

        public ActionResult sitemap()
        {
            return View();
        }

        public ActionResult northRegion()
        {
            return View();
        }

        public ActionResult westRegion()
        {
            return View();
        }

        public ActionResult eastRegion()
        {
            return View();
        }

        public ActionResult southRegion()
        {
            return View();
        }



    }
}