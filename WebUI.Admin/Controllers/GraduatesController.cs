using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.EF;
using DAL.Models;

namespace WebUI.Admin.Controllers
{
    public class GraduatesController : Controller
    {
        private AdminContext db = new AdminContext();

        // GET: Graduates
        public ActionResult Index()
        {
            var graduates = db.Graduates.Include(g => g.Group).Include(g => g.ScienceWork).Include(g => g.Teacher);
            return View(graduates.ToList());
        }

        // GET: Graduates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate graduate = db.Graduates.Find(id);
            if (graduate == null)
            {
                return HttpNotFound();
            }
            return View(graduate);
        }

        // GET: Graduates/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Group_Name");
            ViewBag.Id = new SelectList(db.ScienceWorks, "Id", "Theme");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FIO");
            return View();
        }

        // POST: Graduates/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FIO,TeacherId,GroupId")] Graduate graduate)
        {
            if (ModelState.IsValid)
            {
                db.Graduates.Add(graduate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Group_Name", graduate.GroupId);
            ViewBag.Id = new SelectList(db.ScienceWorks, "Id", "Theme", graduate.Id);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FIO", graduate.TeacherId);
            return View(graduate);
        }

        // GET: Graduates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate graduate = db.Graduates.Find(id);
            if (graduate == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Group_Name", graduate.GroupId);
            ViewBag.Id = new SelectList(db.ScienceWorks, "Id", "Theme", graduate.Id);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FIO", graduate.TeacherId);
            return View(graduate);
        }

        // POST: Graduates/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FIO,TeacherId,GroupId")] Graduate graduate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graduate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Group_Name", graduate.GroupId);
            ViewBag.Id = new SelectList(db.ScienceWorks, "Id", "Theme", graduate.Id);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FIO", graduate.TeacherId);
            return View(graduate);
        }

        // GET: Graduates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate graduate = db.Graduates.Find(id);
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
            Graduate graduate = db.Graduates.Find(id);
            db.Graduates.Remove(graduate);
            db.SaveChanges();
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
