using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Models;

namespace WebUI.Admin.Controllers
{
    public class SchedulesController : Controller
    {
        private UnitOfWorkAdmin work = new UnitOfWorkAdmin();

        // GET: Schedules
        public ActionResult Index()
        {
            
            return View(work.Schedules.GetAll().ToList());
        }

        // GET: Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = work.Schedules.Get(id.Value);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(work.Courses.GetAll(), "Id", "Name");
            ViewBag.GroupId = new SelectList(work.Groups.GetAll(), "Id", "Group_Name");
            ViewBag.TeacherId = new SelectList(work.Teachers.GetAll(), "Id", "FIO");
            return View();
        }

        // POST: Schedules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Schedule schedule)
        {

            if (ModelState.IsValid)
            {
                work.Schedules.Create(schedule);
                work.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(work.Courses.GetAll(), "Id", "Name");
            ViewBag.GroupId = new SelectList(work.Groups.GetAll(), "Id", "Group_Name");
            ViewBag.TeacherId = new SelectList(work.Teachers.GetAll(), "Id", "FIO");
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = work.Schedules.Get(id.Value);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(work.Courses.GetAll(), "Id", "Name");
            ViewBag.GroupId = new SelectList(work.Groups.GetAll(), "Id", "Group_Name");
            ViewBag.TeacherId = new SelectList(work.Teachers.GetAll(), "Id", "FIO");
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                work.Schedules.Update(schedule);
                work.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(work.Courses.GetAll(), "Id", "Name");
            ViewBag.GroupId = new SelectList(work.Groups.GetAll(), "Id", "Group_Name");
            ViewBag.TeacherId = new SelectList(work.Teachers.GetAll(), "Id", "FIO");
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = work.Schedules.Get(id.Value);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
         
            work.Schedules.Delete(id);
            work.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                work.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
