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
    public class JobRepository :IRepository<Job>
    {
        private AdminContext _db;

        public JobRepository(AdminContext db)
        {
            _db = db;
        }

        public void Create(Job item)
        {
            if (item == null)
                throw new NullReferenceException();
            _db.Jobs.Add(item);
        }

        public void Delete(int id)
        {
            Job advertisement = _db.Jobs.Find(id);
            if (advertisement != null)
                _db.Jobs.Remove(advertisement);
        }

        public IEnumerable<Job> Find(Func<Job, bool> predicate)
        {
            return _db.Jobs.Where(predicate).ToList();
        }

        public Job Get(int id)
        {
            return _db.Jobs.Find(id);
        }

        public IEnumerable<Job> GetAll()
        {
            return _db.Jobs;
        }

        public void Update(Job item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}