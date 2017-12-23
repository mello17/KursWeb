using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using DAL.Web.Site.Interfaces;
using System.Web.Mvc;
using DAL.EF;
using DAL;
using DAL.Models;

namespace WebUI.Admin.Controllers
{
    public class TeachersController : Controller
    {
        private AdminContext db = new AdminContext();
        private UnitOfWorkAdmin work = new UnitOfWorkAdmin();

        // GET: Teachers
        public ActionResult Index()
        {
            return View(work.Teachers.GetAll().ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = work.Teachers.Get(id.Value);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FIO,Job,Degree")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                work.Teachers.Create(teacher);
                work.Save();
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = work.Teachers.Get(id.Value);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FIO,Job,Degree")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                work.Teachers.Update(teacher);
                work.Save();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = work.Teachers.Get(id.Value);

            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = work.Teachers.Get(id);
            work.Teachers.Delete(id);
            work.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
