using NewsProject.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsProject.Models;

namespace NewsProject.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {

            
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(News n)
        {
            if (ModelState.IsValid)
            {
                NewsInfoEntities db = new NewsInfoEntities();
                db.News.Add(n);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(n);
        }
        [HttpGet]
        public ActionResult edit(int Id)
        {
            News NewsModel = new News();
            using (NewsInfoEntities NewsInfoEntitie = new NewsInfoEntities())
            {
                NewsModel = NewsInfoEntitie.News.Where(x => x.Id == Id).FirstOrDefault();
            }
            return View(NewsModel);
        }
        [HttpPost]
        public ActionResult edit(News NewsModel)
        {

            using (NewsInfoEntities NewsInfoEntitie = new NewsInfoEntities())
            {
                NewsInfoEntitie.Entry(NewsModel).State = System.Data.EntityState.Modified;
                NewsInfoEntitie.SaveChanges();

            }
            return RedirectToAction("Index");
        }


    }
}
