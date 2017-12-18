using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IUnitOfWorkAdmin 
    {
        IRepository<Course> Courses { get; }
        IRepository<Degree> Degrees { get; }
        IRepository<Graduate> Graduates { get; }
        IRepository<Group> Groups { get; }
        void Save();
        void Dispose();
    }
}
