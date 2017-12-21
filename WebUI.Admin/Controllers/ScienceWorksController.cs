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
    public class ScienceWorksController : Controller
    {
        private AdminContext db = new AdminContext();

        // GET: ScienceWorks
        public ActionResult Index()
        {
            var scienceWorks = db.ScienceWorks.Include(s => s.Graduate);
            return View(scienceWorks.ToList());
        }

        // GET: ScienceWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScienceWork scienceWork = db.ScienceWorks.Find(id);
            if (scienceWork == null)
            {
                return HttpNotFound();
            }
            return View(scienceWork);
        }

        // GET: ScienceWorks/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Graduates, "Id", "FIO");
            return View();
        }

        // POST: ScienceWorks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Theme,ScienceDirection")] ScienceWork scienceWork)
        {
            if (ModelState.IsValid)
            {
                db.ScienceWorks.Add(scienceWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Graduates, "Id", "FIO", scienceWork.Id);
            return View(scienceWork);
        }

        // GET: ScienceWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScienceWork scienceWork = db.ScienceWorks.Find(id);
            if (scienceWork == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Graduates, "Id", "FIO", scienceWork.Id);
            return View(scienceWork);
        }

        // POST: ScienceWorks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Theme,ScienceDirection")] ScienceWork scienceWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scienceWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Graduates, "Id", "FIO", scienceWork.Id);
            return View(scienceWork);
        }

        // GET: ScienceWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScienceWork scienceWork = db.ScienceWorks.Find(id);
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
            ScienceWork scienceWork = db.ScienceWorks.Find(id);
            db.ScienceWorks.Remove(scienceWork);
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
