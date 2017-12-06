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
    public class AnnounceRepository : IRepository<Announce>
    {
        private SiteContext _db;

        public AnnounceRepository(SiteContext db)
        {
            _db = db;
        }

        public void Create(Announce item)
        {
            if (item == null)
                throw new NullReferenceException();
            _db.Announces.Add(item);
        }

        public void Delete(int id)
        {
            Announce advertisement = _db.Announces.Find(id);
            if (advertisement != null)
                _db.Announces.Remove(advertisement);
        }

        public IEnumerable<Announce> Find(Func<Announce, bool> predicate)
        {
            return _db.Announces.Where(predicate).ToList();
        }

        public Announce Get(int id)
        {
            return _db.Announces.Find(id);
        }

        public IEnumerable<Announce> GetAll()
        {
            return _db.Announces;
        }

        public void Update(Announce item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}