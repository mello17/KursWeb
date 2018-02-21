using DAL.Web.Site.Models;
using DAL.Web.Site;
using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;
using DAL.Web.Site.EF;
using System.Data.Entity;

using DAL.Web.Site.Interfaces;

namespace Kurs_project_web.Controllers
{
    public class NewsController : Controller
    {
        SiteContext db;
        UnitOfWork work;
        public NewsController()
        {
           work = new UnitOfWork();
            db = new SiteContext();
        }
        // GET: News
        public ActionResult News()
        {
            
            ViewBag.Message = "Fking news";
            var events = work.AllNews();
            if(events == null)
            {
                return View();
            }
            return View(events);
        }

       public ActionResult GetNews(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);

            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        public ActionResult _PartialLayoutNews()
        {
            ViewBag.Message = "Полный список новостей";

            return PartialView(work.AllNews2());

        }

        public ActionResult AddNews()
        {
            
           var model = new News
            {
                
                //Header= "Мероприятие"
                
            };
            return View(model);
        }
    }
}