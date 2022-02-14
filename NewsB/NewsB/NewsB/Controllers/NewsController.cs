using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsB.Models;
using NewsB.Models.Database;
using System.Data.Entity;

namespace NewsB.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            List<News> Newslist = new List<News>();
            // List<studentEntities> studentlist = new List<studentEntities>();
            using (NewsInfoEntities NewsInfoEntitie = new NewsInfoEntities())
            {

                Newslist = NewsInfoEntitie.News.ToList<News>();
            }
            return View(Newslist);
        }
    

        // GET: News/Details/5
        public ActionResult Details(int Id)
        {
            News NewsModel = new News();
            using (NewsInfoEntities NewsInfoEntitie = new NewsInfoEntities())
            {
                NewsModel = NewsInfoEntitie.News.Where(x => x.Id == Id).FirstOrDefault();
            }
            return View(NewsModel);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View(new News());
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Create(News NewsModel)
        {
            using (NewsInfoEntities NewsInfoEntitie = new NewsInfoEntities())
            {
                NewsInfoEntitie.News.Add(NewsModel);
                NewsInfoEntitie.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {
            News NewsModel = new News();
            using (NewsInfoEntities NewsInfoEntitie = new NewsInfoEntities())
            {
                NewsModel = NewsInfoEntitie.News.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(NewsModel);
        }

        // POST: News/Edit/5
        [HttpPost]
        public ActionResult Edit(News NewsModel)
        {
            using (NewsInfoEntities NewsInfoEntitie = new NewsInfoEntities())
            {
                NewsInfoEntitie.Entry(NewsModel).State = EntityState.Modified;
                NewsInfoEntitie.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            News NewsModel = new News();
            using (NewsInfoEntities NewsInfoEntitie = new NewsInfoEntities())
            {
                NewsModel = NewsInfoEntitie.News.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(NewsModel);
        }

        // POST: News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            using (NewsInfoEntities studentEntitie = new NewsInfoEntities())
            {
                News NewsModel = studentEntitie.News.Where(x => x.Id == id).FirstOrDefault();
                studentEntitie.News.Remove(NewsModel);
                studentEntitie.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
