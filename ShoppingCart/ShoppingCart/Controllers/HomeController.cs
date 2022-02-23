using ShoppingCart.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;
namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        myshopDBEntities db = new myshopDBEntities();
        public ActionResult Index()
        {
           
            var img = db.tblimages.ToList();
            var p = db.tblproes.ToList();
            ViewBag.p = p;
            ViewBag.imgs = img;
            return View();
        }
        public ActionResult cat(int id)
        {
            var p = db.tblproes.Where(l => l.cid == id).ToList();
            var img = db.tblimages.ToList();
            ViewBag.p = p;
            ViewBag.imgs = img;
            return View();
        }

        public ActionResult pro(int id)
        {
            var p = db.tblproes.Where(l => l.pid == id).ToList();
            var img = db.tblimages.Where(l => l.pid == id).ToList();
            ViewBag.p = p;
            ViewBag.imgs = img;
            return View();
        }
        public ActionResult cart()
        {
            ViewBag.c = ok.c;
            return View();
        }
        [HttpPost]
        public ActionResult cart(string pid, string pqty)
        {
            int id = int.Parse(pid);
            var item = db.tblproes.ToList();
           
            foreach(var p in ok.c)
            {
                if(p.iid == id)
                {
                    p.iqty += int.Parse(pqty);
                    ViewBag.c = ok.c;
                    ViewBag.item = item;
                    return View();

                }
               
            }
            item i = new item()
            {
                iid = id,
                iqty = int.Parse(pqty)

            };

            ok.c.Add(i);
            ViewBag.c = ok.c;
            ViewBag.item = item;

            return View();
            
        }
        [HttpPost]
        public ActionResult checkout(string total)
        {
           
            ViewBag.t = total;
            return View();
        }
        [HttpPost]
        public ActionResult doneorder(tblorder tb, string total)
        {
            tblorder obj = new tblorder();
            obj.odate = DateTime.Now;
            obj.oamount = int.Parse(total);
            obj.ostatus = 0;
            obj.opname = tb.opname;
            obj.opaddress = tb.opaddress;
            obj.opsaddress = tb.opsaddress;
            obj.opphone = tb.opphone;
            db.tblorders.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}