using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Web.Site.Models;

namespace DAL.Web.Site.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Announce> User { get; }
        IRepository<PhotoAlbum> Advertisement { get; }
        IRepository<News> News { get; }
        int Save();

    }
}
