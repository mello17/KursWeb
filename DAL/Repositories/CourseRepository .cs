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
    public class CourseRepository : IRepository<Course>
    {
        private AdminContext _db;

        public CourseRepository(AdminContext db)
        {
            _db = db;

        }

        public void Create(Course item)
        {
            if (item == null)
                throw new NullReferenceException();
            _db.Courses.Add(item);
        }

        public void Delete(int id)
        {
            Course advertisement = _db.Courses.Find(id);
            if (advertisement != null)
                _db.Courses.Remove(advertisement);
        }

        public IEnumerable<Course> Find(Func<Course, bool> predicate)
        {
            return _db.Courses.Where(predicate).ToList();
        }

        public Course Get(int id)
        {
            return _db.Courses.Find(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _db.Courses;
        }

        public void Update(Course item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}