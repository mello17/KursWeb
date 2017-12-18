using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Web.Site.Models;

namespace DAL.Web.Site.Interfaces
{
    public interface IUnitOfWork 
    {
        IRepository<PhotoAlbum> PhotoAlbums { get; }
        IRepository<News> News { get; }
        void Save();
        void Dispose();

    }
}
