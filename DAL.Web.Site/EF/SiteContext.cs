using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DAL.Web.Site.Models;

namespace DAL.Web.Site.EF
{
    public class SiteContext : DbContext
    {

        public SiteContext() : base("SiteDB")
        { }

       // public DbSet<Announce> Announces { get; set; }
        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }
        public DbSet<News> News { get; set; }
    }
}