using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using DAL;
using System.Web;
using System.Web.Mvc;
using DAL.EF;
using DAL.Models;

namespace WebUI.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GroupsController : Controller
    {
        private UnitOfWorkAdmin work = new UnitOfWorkAdmin();

        // GET: Groups
        public ActionResult Index()
        {
            return View(work.Groups.GetAll().ToList());
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = work.Groups.Get(id.Value);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Group_Name,Count_Of_Student")] Group group)
        {
            if (ModelState.IsValid)
            {
                work.Groups.Create(group);
                work.Save();
                return RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = work.Groups.Get(id.Value);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Group_Name,Count_Of_Student")] Group group)
        {
            if (ModelState.IsValid)
            {
                work.Groups.Update(group);
                work.Save();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = work.Groups.Get(id.Value);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = work.Groups.Get(id);
            work.Groups.Delete(id);
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
