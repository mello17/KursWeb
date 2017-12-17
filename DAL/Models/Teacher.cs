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
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int DegreeId { get; set; }
        public Degree Degree { get; set; }

        public ICollection<Group> Groups { get; set; }
        
        public ICollection<Graduate> Graduates { get; set; }
        public ICollection<Course> Courses { get; set; }

        public Teacher()
        {
            Groups = new List<Group>();
           
            Graduates = new List<Graduate>();
            Courses = new List<Course>();
        }
    }
}