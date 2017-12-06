using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Web.Site.Models
{
    public class PhotoAlbum
    {
        public int Id { get; set; }
        public string Path_To_Photo { get; set; }
        public string Alt { get; set; }
        public string Gallery { get; set; }
    }
}