using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Schedule
    {
        //Это не график. Это расписание занятий
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Преподаватель")]
        public int TeacherId { get; set; }
        [Required]
        [Display(Name = "Группа")]
        public int GroupId { get; set; }
        [Display(Name = "Предмет")]
        [Required]
        public int CourseId { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Время начала")]
        public string TimeStartingSchedule { get; set; }

        [Required]
        [Display(Name ="Номер по порядку")]
        [Range(1,7)]
        public int NumberLesson { get; set; }


        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Время окончания")]
        public string TimeEndingSchedule { get; set; }

        [Required]
        [Display(Name = "День недели")]
        public Days Day { get; set; }

        [Required]
        [Display(Name = "Аудитория")]
        public string Auditory { get; set; }

        
        public Group Group { get; set; }
       
        public Teacher Teacher { get; set; }
        
        public Course Course { get; set; }

        public Schedule()
        {
            //TimeStartingSchedule = new DateTime().ToShortTimeString();
            //TimeEndingSchedule = new DateTime().ToShortTimeString();
        }
    }
    
}
  