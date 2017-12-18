using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.Web.Site.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }//С чего бы это у новости нет ID?      
        public string Content { get; set; }//
        public string Header { get; set; }
        public DateTime CurrentDate { get; set; }
        public string Type { get; set; }//Тип - новость/статья/объявление     
        public string AuthorProfileId { get; set; } // Автор новости
        public News()
        {
            CurrentDate = DateTime.Now;
        }

        public string imgPath { get; set; }//путь к изображению-заголовку. Это надо.

        public IEnumerable<string> Items { get; set; }
    }
}