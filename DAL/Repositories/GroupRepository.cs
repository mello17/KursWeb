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
    public class GroupRepository :IRepository<Group>
    {
        private AdminContext _db;

        public GroupRepository(AdminContext db)
        {
            _db = db;
        }

        public void Create(Group item)
        {
            if (item == null)
                throw new NullReferenceException();
            _db.Groups.Add(item);
        }

        public void Delete(int id)
        {
            Group advertisement = _db.Groups.Find(id);
            if (advertisement != null)
                _db.Groups.Remove(advertisement);
        }

        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            return _db.Groups.Where(predicate).ToList();
        }

        public Group Get(int id)
        {
            return _db.Groups.Find(id);
        }

        public IEnumerable<Group> GetAll()
        {
            return _db.Groups;
        }

        public void Update(Group item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}