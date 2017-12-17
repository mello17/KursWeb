using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.EF;
using System.Data.Entity;
using DAL.Models;
using DAL.Web.Site.Interfaces;
namespace DAL.Web.Site.Repositories
{
    public class DegreeRepository : IRepository<Degree>
    {
        private AdminContext _db;

        public DegreeRepository(AdminContext db)
        {
            _db = db;
        }

        public void Create(Degree item)
        {
            if (item == null)
                throw new NullReferenceException();
            _db.Degrees.Add(item);
        }

        public void Delete(int id)
        {
            Degree advertisement = _db.Degrees.Find(id);
            if (advertisement != null)
                _db.Degrees.Remove(advertisement);
        }

        public IEnumerable<Degree> Find(Func<Degree, bool> predicate)
        {
            return _db.Degrees.Where(predicate).ToList();
        }

        public Degree Get(int id)
        {
            return _db.Degrees.Find(id);
        }

        public IEnumerable<Degree> GetAll()
        {
            return _db.Degrees;
        }

        public void Update(Degree item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}