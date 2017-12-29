﻿using DAL.Web.Site.Models;
using DAL.Web.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Web.Site.EF;
using System.Data.Entity;

using DAL.Web.Site.Interfaces;

namespace Kurs_project_web.Controllers
{
    public class NewsController : Controller
    {
        private SiteContext db = new SiteContext();
        UnitOfWork work;
        public NewsController()
        {
           work = new UnitOfWork();
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

        public ActionResult _PartialLayoutNews()
        {
            ViewBag.Message = "Полный список новостей";
            // Отстой. Дублированный код. Самому мерзко. 
            var News = work.AllNews2();
            return PartialView(News);
            //return PartialView();
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