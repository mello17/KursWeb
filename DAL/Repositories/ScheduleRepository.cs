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
    public class ScheduleRepository :IRepository<Schedule>
    {
        private AdminContext _db;

        public ScheduleRepository(AdminContext db)
        {
            _db = db;
        }

        public void Create(Schedule item)
        {
            if (item == null)
                throw new NullReferenceException();
            _db.Schedules.Add(item);
        }

        public void Delete(int id)
        {
            Schedule advertisement = _db.Schedules.Find(id);
            if (advertisement != null)
                _db.Schedules.Remove(advertisement);
        }

        public IEnumerable<Schedule> Find(Func<Schedule, bool> predicate)
        {
            return _db.Schedules.Where(predicate).ToList();
        }

        public Schedule Get(int id)
        {
            return _db.Schedules.Find(id);
        }

        public IEnumerable<Schedule> GetAll()
        {
            var schedules = _db.Schedules.Include(s => s.Course).Include(s => s.Group).Include(s => s.Teacher);
            return schedules;
        }

        public void Update(Schedule item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}