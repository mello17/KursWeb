using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Schedule
    {
        //Это не график. Это расписание занятий
        [Key]
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        public int CourseId { get; set; }

        [Required]
        public DateTime Time { get; set; }
        [Required]
        public string Auditory { get; set; }

        public Group Group { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }

    }
}