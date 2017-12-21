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
    public class TeacherRepository :IRepository<Teacher>
    {
        AdminContext _db;

        public TeacherRepository(AdminContext db)
        {
            _db = db;
        }

        public void Create(Teacher item)
        {
            if (item == null)
                throw new NullReferenceException();
            _db.Teachers.Add(item);
        }

        public void Delete(int id)
        {
            Teacher advertisement = _db.Teachers.Find(id);
            if (advertisement != null)
                _db.Teachers.Remove(advertisement);
        }

        public IEnumerable<Teacher> Find(Func<Teacher, bool> predicate)
        {
            return _db.Teachers.Where(predicate).ToList();
        }

        public Teacher Get(int id)
        {
            return _db.Teachers.Find(id);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _db.Teachers;
        }

        public void Update(Teacher item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}