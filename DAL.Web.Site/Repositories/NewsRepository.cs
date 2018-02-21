using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Web.Site.EF;
using System.Data.Entity;
using DAL.Web.Site.Models;
using DAL.Web.Site.Interfaces;
namespace DAL.Web.Site.Repositories
{
    public class NewsRepository : IRepository<News>
    {
        private SiteContext _db;

        public NewsRepository(SiteContext db)
        {
            _db = db;
        }
        public void NewsRepositoryMock()
        {
           var _news = new List<News>
            {
                new News
                {
                    Id = 1,
                    Header = "Новость 1",
                    Content = "Описание новости 1",
                    
                },
                new News
                {
                    Id = 2,
                    Header = "Мероприятие 1",
                    Content = "Описание мероприятия 2",
                    
                },
                new News
                {
                    Id = 3,
                    Header = "Объявление 1",
                    Content = "Описание объявления 3",
                   
                }
            };
        }

        public void Create(News item)
        {
            if (item == null)
                throw new NullReferenceException();
            _db.News.Add(item);
        }

        public void Delete(int id)
        {
            News advertisement = _db.News.Find(id);
            if (advertisement != null)
                _db.News.Remove(advertisement);
        }

        public IEnumerable<News> Find(Func<News, bool> predicate)
        {
            return _db.News.Where(predicate).ToList();
        }

        public News Get(int id)
        {
            return _db.News.Find(id);
        }

        public IEnumerable<News> GetAll()
        {
            return _db.News;
        }

        public void Update(News item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }     
    }
}