using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlTypes;
using System.Data.Entity;
using DAL.Models;

namespace DAL.EF
{
    public class AdminContext : DbContext
    {
        public AdminContext() : base("SiteDB")
        { }


        public DbSet<Course> Courses { get; set; }
        public DbSet<ScienceWork> ScienceWorks { get; set; }
        public DbSet<Graduate> Graduates { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public override int SaveChanges()
        {
            UpdateDates();
            return base.SaveChanges();
        }

        private void UpdateDates()
        {
            foreach (var change in ChangeTracker.Entries<AdminContext>())
            {
                var values = change.CurrentValues;
                foreach (var name in values.PropertyNames)
                {
                    var value = values[name];
                    if (value is DateTime)
                    {
                        var date = (DateTime)value;
                        if (date < SqlDateTime.MinValue.Value)
                        {
                            values[name] = SqlDateTime.MinValue.Value;
                        }
                        else if (date > SqlDateTime.MaxValue.Value)
                        {
                            values[name] = SqlDateTime.MaxValue.Value;
                        }
                    }
                }
            }

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
                
        }

    }
}