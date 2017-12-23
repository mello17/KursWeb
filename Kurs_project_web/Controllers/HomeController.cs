using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Web.Site;
using DAL;
using DAL.Web.Site.Repositories;
using DAL.Web.Site.EF;
using DAL.Web.Site.Models;
using System.Globalization;
using DAL;

namespace Kurs_project_web.Controllers
{

    public class HomeController : Controller
    {   
        public SiteContext db = new SiteContext();
        UnitOfWork work;
        UnitOfWorkAdmin admin_work;

        public HomeController()
        {
            work = new UnitOfWork();
            admin_work = new UnitOfWorkAdmin();
        }
      //  public NewsRepository repository = new NewsRepository(db);

        public ActionResult Index()
        {
            // var News = db.News.ToList();
            var News = work.AllNews();
            return View(News);
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
           

            return View();
        }

        public ActionResult StudentsView()
        {
            
            var students = admin_work.Graduates.GetAll();
            return View(students);
        }

        public ActionResult TeachersView()
        {
            
            var teachers = admin_work.Teachers.GetAll();
            return View(teachers);
        }

        public ActionResult TimeTableView()
        {
           
           // var  = db.Teacher.ToList();
            return View();
        }

        // GET: News

        //private NewsRepository newsRepos = new NewsRepository(_db);

        public ActionResult News()
        {

            new News
            {
                Id = 1,
                Header = "Новость 1",
                Content = "Описание новости 1",
                Type = "Новость"
            };
                new News
                {
                    Id = 2,
                    Header = "Мероприятие 1",
                    Content = "Описание мероприятия 2",
                    Type = "Мероприятия"
                };
            new News
            {
                Id = 3,
                Header = "Объявление 1",
                Content = "Описание объявления 3",
                Type = "Объявления"
            };
                var News = db.News.ToList();
            return View(News);
        }


        public ActionResult _PartialIndexArticles()
        {
            var News = work.AllArticle();
            return PartialView(News);
           
        }
        public ActionResult _PartialLayoutNews()
        {  
            // var News = db.News.ToList(); 
            var News = work.AllNews2();
            return PartialView(News);
           
        }

        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
    }
}