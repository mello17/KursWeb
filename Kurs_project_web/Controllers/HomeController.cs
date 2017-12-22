using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Web.Site;
using DAL.Web.Site.Repositories;
using DAL.Web.Site.EF;
using DAL.Web.Site.Models;
using DAL.Models;
using Kurs_project_web.Filters;

namespace Kurs_project_web.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        public SiteContext db = new SiteContext();
        UnitOfWork work;
        public HomeController()
        {
            work = new UnitOfWork();
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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StudentsView()
        {
            ViewBag.Message = "Your ption page.";

            return View();
        }

        public ActionResult TeachersView()
        {
            ViewBag.Message = "Your application  page.";

            return View();
        }

        public ActionResult TimeTableView()
        {
            ViewBag.Message = "Your applicaon page.";
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
            ViewBag.Message = "Частичное представление - вывод 3 cтатей на главную";
            var News = work.AllArticle();
            return PartialView(News);
           
        }
        public ActionResult _PartialLayoutNews()
        {
            ViewBag.Message = "Частичное представление - вывод новостей в layout";
            // var News = db.News.ToList(); 
            var News = work.AllNews();
            return PartialView(News);
           
        }
        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string>() { "rus", "eng"};
            if (!cultures.Contains(lang))
            {
                lang = "rus";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
    }
}