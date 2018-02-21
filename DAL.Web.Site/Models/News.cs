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
        public int Id { get; set; }   
        [Display(Name ="Заголовок")]
        [Required]
        public string Header { get; set; }
        [Display(Name = "Cодержимое")]
        [Required]
        public string Content { get; set; }
        public DateTime CurrentDate { get; set; }//Дата создания?
       
        public News()
        {
            CurrentDate = DateTime.Now;
        }

        [Display(Name = "Изображение")]
        public string imgPath { get; set; }//путь к изображению-заголовку. Это надо.

    }
}