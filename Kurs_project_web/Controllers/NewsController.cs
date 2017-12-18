using DAL.Web.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Web.Site.EF;
using System.Data.Entity;
using DAL.Web.Site.Models;
using DAL.Web.Site.Interfaces;

namespace Kurs_project_web.Controllers
{
    public class NewsController : Controller
    {
        private SiteContext db = new SiteContext();
        // GET: News
        public ActionResult News()
        {
            ViewBag.Message = "Fking news";

            return View(db.News.ToList());
        }

        public ActionResult AddNews()
        {
            var model = new News
            {
                Items = new List<string>
                {
                    "Новость",
                    "Мероприятие",
                    "Объявление"
                }
            };
            return View(model);
        }
    }
}