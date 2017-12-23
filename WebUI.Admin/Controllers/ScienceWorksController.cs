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
    public class ScienceWorksController : Controller
    {

        private UnitOfWorkAdmin work = new UnitOfWorkAdmin();

        // GET: ScienceWorks
        public ActionResult Index()
        {
            
            return View(work.ScienceWorks.GetAll().ToList());
        }

        // GET: ScienceWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScienceWork scienceWork = work.ScienceWorks.Get(id.Value);
            if (scienceWork == null)
            {
                return HttpNotFound();
            }
            return View(scienceWork);
        }

        // GET: ScienceWorks/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(work.Graduates.GetAll(), "Id", "FIO");
            return View();
        }

        // POST: ScienceWorks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Theme,ScienceDirection")] ScienceWork scienceWork)
        {
            if (ModelState.IsValid)
            {
                work.ScienceWorks.Create(scienceWork);
                work.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(work.Graduates.GetAll(), "Id", "FIO");
            return View(scienceWork);
        }

        // GET: ScienceWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScienceWork scienceWork = work.ScienceWorks.Get(id.Value);
            if (scienceWork == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(work.Graduates.GetAll(), "Id", "FIO");
            return View(scienceWork);
        }

        // POST: ScienceWorks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Theme,ScienceDirection")] ScienceWork scienceWork)
        {
            if (ModelState.IsValid)
            {
                work.ScienceWorks.Update(scienceWork);
                work.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(work.Graduates.GetAll(), "Id", "FIO");
            return View(scienceWork);
        }

        // GET: ScienceWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScienceWork scienceWork = work.ScienceWorks.Get(id.Value);
            if (scienceWork == null)
            {
                return HttpNotFound();
            }
            return View(scienceWork);
        }

        // POST: ScienceWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            work.ScienceWorks.Delete(id);
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
