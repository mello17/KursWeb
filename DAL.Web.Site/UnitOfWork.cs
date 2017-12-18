using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Web.Site.Interfaces;
using DAL.Web.Site.EF;
using DAL.Web.Site.Models;
using DAL.Web.Site.Repositories;
namespace DAL.Web.Site
{
	public class UnitOfWork : IUnitOfWork,INewsRepository
	{
        
        private SiteContext site_db = new SiteContext();
        private bool disposed = false;
        private NewsRepository _newsRepository;
        private PhotoAlbumRepository _photoRepository;
        private AnnounceRepository _announceRepository;

        public IRepository<News> News
        {
            get
            {
                if (_newsRepository == null)
                    _newsRepository = new NewsRepository(site_db);
                return _newsRepository;
            }
        }

        public IRepository<PhotoAlbum> PhotoAlbums
        {
            get
            {
                if (_photoRepository == null)
                    _photoRepository = new PhotoAlbumRepository(site_db);
                return _photoRepository;
            }
        }

        public IRepository<Announce> Announces
        {
            get
            {
                if (_announceRepository == null)
                    _announceRepository = new AnnounceRepository(site_db);
                return _announceRepository;
            }
        }

        public void Save()
        {
            site_db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    site_db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<News> AllNews()
        {
            return site_db.Set<News>().Where(u => u.Type == "Новость");
        }

        public IQueryable<News> AllEvents()
        {
            return site_db.Set<News>().Where(u => u.Type == "Мероприятия");
        }

        public IQueryable<News> AllArticle()
        {
            return site_db.Set<News>().Where(u => u.Type == "Статьи");
        }

    }
}