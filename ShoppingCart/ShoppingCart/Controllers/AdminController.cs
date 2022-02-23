using ShoppingCart.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.msg = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbluser user)
        {
            myshopDBEntities db = new myshopDBEntities();
            var a = db.tblusers.Where(u => u.uname.Equals(user.uname) && u.upass.Equals(user.upass)).ToList();
            if(a.Count > 0)
            {
                Session["uname"] = user.uname.ToString();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid User Name or Password";
            }
            return View();
        }
        public ActionResult Dashboard()
        {
            if(Session["uname"] == null)
            {
                ViewBag.msg = "Login First";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}