using DAL.Web.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Web.Site.Interfaces
{
    public interface INewsRepository 
    {
        IQueryable<News> AllNews();
        IQueryable<News> AllEvents();
        IQueryable<News> AllArticle();
    }
}