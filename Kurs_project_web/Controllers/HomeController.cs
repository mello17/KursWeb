using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Web.Site;
using DAL;
using DAL.Models;
using DAL.Web.Site.Repositories;
using DAL.Web.Site.EF;
using DAL.Web.Site.Models;
using System.Globalization;
using System.Collections;
using System.Web.Security;

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

        public ActionResult GetTeacher(int id)
        {
            Teacher teacher = admin_work.Teachers.Get(id);

            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

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

        public ActionResult GetSchedules(string group)
        {
            IEnumerable<Schedule> list = null;

            if (Request.IsAjaxRequest() && group != String.Empty)
            {
                list = admin_work.Schedules.GetAll().Where(p => p.Group.Group_Name == group);
            }

            return PartialView(list);

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
            ViewBag.GroupId = new SelectList(admin_work.Groups.GetAll(), "Id", "Group_Name");
            var schedules = admin_work.Schedules.GetAll().OrderBy(e=>e.TimeStartingSchedule);   
            return View(schedules);
        }

        [HttpPost]
        public ActionResult TimeTableView(string group)
        {
            if (Request.IsAjaxRequest()) { }

            return View();
        }

        // GET: News


        public ActionResult News()
        {

            new News
            {
                Id = 1,
                Header = "Новость 1",
                Content = "Описание новости 1",
               
            };
                new News
                {
                    Id = 2,
                    Header = "Мероприятие 1",
                    Content = "Описание мероприятия 2",
                   
                };
            new News
            {
                Id = 3,
                Header = "Объявление 1",
                Content = "Описание объявления 3",
               
            };
                var News = db.News.ToList();
            return View(News);
        }


        public ActionResult _PartialIndexArticles()
        {
            var News = work.AllNews2();
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