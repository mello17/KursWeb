using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//using DAL.Interfaces;
using DAL.EF;
using DAL.Models;
using DAL.Repositories;
using DAL.Web.Site.Repositories;
using DAL.Web.Site.Interfaces;

namespace DAL
{
	public class UnitOfWorkAdmin
	{
        private AdminContext admin_db = new AdminContext();
        private bool disposed = false;
        private TeacherRepository _teacherRepository;
        private GroupRepository _groupRepository;
        private GraduateRepository _graduateRepository;
        private ScienceWorkRepository _scienceRepository;
        private ScheduleRepository _scheduleRepository;
        private CourseRepository _courseRepository;

        public IRepository<Teacher> Teachers
        {
            get
            {
                if (_teacherRepository == null)
                    _teacherRepository = new TeacherRepository(admin_db);
                return _teacherRepository;
            }
        }

        public IRepository<Group> Groups
        {
            get
            {
                if (_groupRepository == null)
                    _groupRepository = new GroupRepository(admin_db);
                return (IRepository<Group>)_groupRepository;
            }
        }

        public IRepository<Graduate> Graduates
        {
            get
            {
                if (_graduateRepository == null)
                    _graduateRepository = new GraduateRepository(admin_db);
                return (IRepository<Graduate>)_graduateRepository;
            }
        }

        public IRepository<ScienceWork> ScienceWorks
        {
            get
            {
                if (_scienceRepository == null)
                    _scienceRepository = new ScienceWorkRepository(admin_db);
                return (IRepository<ScienceWork>)_scienceRepository;
            }
        }
        public IRepository<Course> Courses
        {
            get
            {
                if (_courseRepository == null)
                    _courseRepository = new CourseRepository(admin_db);
                return (IRepository<Course>)_courseRepository;
            }
        }
        public IRepository<Schedule> Schedules
        {
            get
            {
                if (_scienceRepository == null)
                    _scheduleRepository = new ScheduleRepository(admin_db);
                return (IRepository<Schedule>)_scienceRepository;
            }
        }

        public void Save()
        {
            admin_db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    admin_db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}