using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Web.Site.Models
{
    public class News
    {
        public int Id { get; set; }//С чего бы это у новости нет ID?
        public string AuthorProfileId { get; set; } // Автор новости
        public string Content { get; set; }//
        public string Header { get; set; }
        public DateTime CurrentDate { get; set; }
        public string Type { get; set; }//Тип - новость/статья/объявление
        

        public News()
        {
            CurrentDate = DateTime.Now;
        }

    }
}