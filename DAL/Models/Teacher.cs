using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Teacher
    {   //преподаватель
        [Key]
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        [Display(Name ="Должность")]
        public Job Job { get; set; }
        [Display(Name = "Ученная степень")]
        public Degree Degree { get; set; }

        public ICollection<Group> Groups { get; set; }
        public ICollection<Graduate> Graduates { get; set; }
        public ICollection<Course> Courses { get; set; }

        [Display(Name = "Фотография")]
        public string imgPath { get; set; }//путь к фото
        [Display(Name = "Биография")]
        public string Information { get; set; }//Описание/информация/биография
        public Teacher()
        {
            Groups = new List<Group>();
            Graduates = new List<Graduate>();
            Courses = new List<Course>();
        }
    }
}