using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.EF;
using DAL.Models;
using System.Data.Entity;
using DAL.Web.Site.Interfaces;

namespace DAL.Repositories
{
    public class ScienceWorkRepository :IRepository<ScienceWork>
    {
        AdminContext _db;

        public ScienceWorkRepository(AdminContext db)
        {
            _db = db;
        }

        public void Create(ScienceWork item)
        {
            if (item == null)
                throw new NullReferenceException();
            _db.ScienceWorks.Add(item);
        }

        public void Delete(int id)
        {
            ScienceWork advertisement = _db.ScienceWorks.Find(id);
            if (advertisement != null)
                _db.ScienceWorks.Remove(advertisement);
        }

        public IEnumerable<ScienceWork> Find(Func<ScienceWork, bool> predicate)
        {
            return _db.ScienceWorks.Where(predicate).ToList();
        }

        public ScienceWork Get(int id)
        {
            return _db.ScienceWorks.Find(id);
        }

        public IEnumerable<ScienceWork> GetAll()
        {
            var scienceWorks = _db.ScienceWorks.Include(s => s.Graduate);
            return scienceWorks;
        }

        public void Update(ScienceWork item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}