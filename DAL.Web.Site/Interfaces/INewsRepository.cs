using DAL.Web.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Web.Site.Interfaces
{
    public interface INewsRepository : IRepository<News>
    {
        IQueryable<News> AllNewses();
        IQueryable<News> AllEvents();
        IQueryable<News> AllArticle();
    }
}