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
    /*
     <===========================Этот вариант мне кажется более логичным=================================>
     
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

        IEnumerable<Lesson> Lessons;//Множество уроков
    }

    public class LessonRequest
    {
        public string name { get; set; }
        public string teacher { get; set; }
    }

    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int number { get; set; }
        [Required]
        public int day { get; set; }
        [Required]
        public string name { get; set; }//Название
        [Required]
        public int TimetableId { get; set; }

        public string TeachersName { get; set; }
        [ForeignKey("TimetableId")]
        public Schedule timetable { get; set; }
    }
     
     
     
     
     
     
     
     
     
     
     
     
     
     */
}