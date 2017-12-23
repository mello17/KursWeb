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
    public class GraduatesController : Controller
    {
        private UnitOfWorkAdmin work = new UnitOfWorkAdmin();
        // GET: Graduates
        public ActionResult Index()
        {
         
            return View(work.Graduates.GetAll().ToList());
        }

        // GET: Graduates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate graduate = work.Graduates.Get(id.Value);
            if (graduate == null)
            {
                return HttpNotFound();
            }
            return View(graduate);
        }

        // GET: Graduates/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(work.Groups.GetAll(), "Id", "Group_Name");
            ViewBag.Id = new SelectList(work.ScienceWorks.GetAll(), "Id", "Theme");
            ViewBag.TeacherId = new SelectList(work.Teachers.GetAll(), "Id", "FIO");
            return View();
        }

        // POST: Graduates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FIO,TeacherId,GroupId")] Graduate graduate)
        {
            if (ModelState.IsValid)
            {
                work.Graduates.Create(graduate);
                work.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(work.Groups.GetAll(), "Id", "Group_Name");
            ViewBag.Id = new SelectList(work.ScienceWorks.GetAll(), "Id", "Theme");
            ViewBag.TeacherId = new SelectList(work.Teachers.GetAll(), "Id", "FIO");
            return View(graduate);
        }

        // GET: Graduates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate graduate = work.Graduates.Get(id.Value);
            if (graduate == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(work.Groups.GetAll(), "Id", "Group_Name", graduate.GroupId);
            ViewBag.Id = new SelectList(work.ScienceWorks.GetAll(), "Id", "Theme", graduate.Id);
            ViewBag.TeacherId = new SelectList(work.Teachers.GetAll(), "Id", "FIO", graduate.TeacherId);
            return View(graduate);
        }

        // POST: Graduates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FIO,TeacherId,GroupId")] Graduate graduate)
        {
            if (ModelState.IsValid)
            {
                work.Graduates.Update(graduate);
                work.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(work.Groups.GetAll(), "Id", "Group_Name", graduate.GroupId);
            ViewBag.Id = new SelectList(work.ScienceWorks.GetAll(), "Id", "Theme", graduate.Id);
            ViewBag.TeacherId = new SelectList(work.Teachers.GetAll(), "Id", "FIO", graduate.TeacherId);
            return View(graduate);
        }

        // GET: Graduates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate graduate = work.Graduates.Get(id.Value);
            if (graduate == null)
            {
                return HttpNotFound();
            }
            return View(graduate);
        }

        // POST: Graduates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            work.Graduates.Delete(id);
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
