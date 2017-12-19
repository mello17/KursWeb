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
        IRepository<Group> Groups { get; }
        IRepository<Graduate> Job { get; }
        IRepository<Schedule> Schedules { get; }
        IRepository<ScienceWork> ScienceWorks { get; }
        IRepository<Teacher> Teachers { get; }
        void Save();
        void Dispose();
    }
}
