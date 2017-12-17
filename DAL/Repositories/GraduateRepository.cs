using System.Web;
using DAL.EF;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using DAL.Web.Site.Interfaces;
using System;

namespace DAL.Repositories
{
    public class GraduateRepository : IRepository<Graduate>
    {
        private AdminContext _db;

        public GraduateRepository(AdminContext db)
        {
            _db = db;
        }

        public void Create(Graduate item)
        {
            if (item == null)
                throw new NullReferenceException();
            _db.Graduates.Add(item);
        }

        public void Delete(int id)
        {
            Graduate advertisement = _db.Graduates.Find(id);
            if (advertisement != null)
                _db.Graduates.Remove(advertisement);
        }

        public IEnumerable<Graduate> Find(Func<Graduate, bool> predicate)
        {
            return _db.Graduates.Where(predicate).ToList();
        }

        public Graduate Get(int id)
        {
            return _db.Graduates.Find(id);
        }

        public IEnumerable<Graduate> GetAll()
        {
            return _db.Graduates;
        }

        public void Update(Graduate item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}