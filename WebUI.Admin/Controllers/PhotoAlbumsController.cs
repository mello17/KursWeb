using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Web.Site.EF;
using DAL.Web.Site.Models;
using DAL.Web.Site;


namespace WebUI.Admin.Controllers
{
    public class PhotoAlbumsController : Controller
    {
        private UnitOfWork db;

        public PhotoAlbumsController()
        {
            db = new UnitOfWork();
        }

        // GET: PhotoAlbums
        public ActionResult Index()
        {
            return View(db.PhotoAlbums.GetAll().ToList());
        }

        // GET: PhotoAlbums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoAlbum photoAlbum = db.PhotoAlbums.Get(id.Value);
            if (photoAlbum == null)
            {
                return HttpNotFound();
            }
            return View(photoAlbum);
        }

        // GET: PhotoAlbums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhotoAlbums/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Path_To_Photo,Alt,Gallery")] PhotoAlbum photoAlbum, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                photoAlbum.Path_To_Photo = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Files/" + photoAlbum.Path_To_Photo));
            }

            if (ModelState.IsValid)
            {
                db.PhotoAlbums.Create(photoAlbum);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(photoAlbum);
        }

        // GET: PhotoAlbums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoAlbum photoAlbum = db.PhotoAlbums.Get(id.Value);
            if (photoAlbum == null)
            {
                return HttpNotFound();
            }
            return View(photoAlbum);
        }

        // POST: PhotoAlbums/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Path_To_Photo,Alt,Gallery")] PhotoAlbum photoAlbum, HttpPostedFileBase upload)
        {

            if (upload != null)
            {
                // получаем имя файла
                photoAlbum.Path_To_Photo = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Files/" + photoAlbum.Path_To_Photo));
            }

            if (ModelState.IsValid)
            {
                db.PhotoAlbums.Update(photoAlbum);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(photoAlbum);
        }

        // GET: PhotoAlbums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoAlbum photoAlbum = db.PhotoAlbums.Get(id.Value);
            if (photoAlbum == null)
            {
                return HttpNotFound();
            }
            return View(photoAlbum);
        }

        // POST: PhotoAlbums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
    
            db.PhotoAlbums.Delete(id);
            db.Save();
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
