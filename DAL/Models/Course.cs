using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Course
    {//Предмет
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0,24)]
        public int CountOfSemester { get; set; }
        [Required]
        [Range(0, 12)]
        public int NumCourse { get; set; }
    }
}