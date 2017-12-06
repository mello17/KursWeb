using System.Web;
using DAL.Web.Site.EF;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using DAL.Web.Site.Models;
using DAL.Web.Site.Interfaces;
using System;

namespace DAL.Web.Site.Repositories
{
    public class PhotoAlbumRepository : IRepository<PhotoAlbum>
    {
        private SiteContext _db;

        public PhotoAlbumRepository(SiteContext db)
        {
            _db = db;
        }

        public void Create(PhotoAlbum item)
        {
            if (item == null)
                throw new NullReferenceException();
            _db.PhotoAlbums.Add(item);
        }

        public void Delete(int id)
        {
            PhotoAlbum advertisement = _db.PhotoAlbums.Find(id);
            if (advertisement != null)
                _db.PhotoAlbums.Remove(advertisement);
        }

        public IEnumerable<PhotoAlbum> Find(Func<PhotoAlbum, bool> predicate)
        {
            return _db.PhotoAlbums.Where(predicate).ToList();
        }

        public PhotoAlbum Get(int id)
        {
            return _db.PhotoAlbums.Find(id);
        }

        public IEnumerable<PhotoAlbum> GetAll()
        {
            return _db.PhotoAlbums;
        }

        public void Update(PhotoAlbum item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}