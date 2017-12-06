using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DAL.Models;

namespace DAL.EF
{
    public class AdminContext : DbContext
    {
        public AdminContext() : base("SiteDB")
        { }

        public DbSet<Acadeemic> Academics { get; set; }
        public DbSet<Disciple> Disciples { get; set; }
        public DbSet<Graduate> Graduates { get; set; }
        public DbSet<Group> Groups{ get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


    }
}