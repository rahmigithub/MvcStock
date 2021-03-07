using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcStok.BusinessProcess;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        // GET: User

        MvcDbStokEntities db = DatabaseController.getSingleton().getDB();
        public ActionResult Index()
        {

            if (Session["Name"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        
        [HttpGet]
        public ActionResult Login() {


            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(TBLUSER p1) {






            var data = db.TBLUSERs.FirstOrDefault(x => x.USERNAME == p1.USERNAME && x.USERPASSWORD == x.USERPASSWORD);
               
                if (data!=null)
                {

                FormsAuthentication.SetAuthCookie(data.USERNAME, false);
                //add session
                //Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                Session["Name"] = data.USERNAME;
                //Session["Id"] = data.USERID;
                //Session["idUser"] = data.FirstOrDefault().USERPASSWORD;
                return RedirectToAction("Index","User");
                }
                else
                {
                    ViewBag.error = "Hatalı giriş";
                    return RedirectToAction("Login");
                }
            
            //return View();


        }

     

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

    }
}