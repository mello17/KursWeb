using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Название группы")]
        public string Group_Name{ get; set; }
        public ICollection<Graduate> Graduates { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public Group()
        {
            Graduates = new List<Graduate>();
            Schedules = new List<Schedule>();
        }

    }
}