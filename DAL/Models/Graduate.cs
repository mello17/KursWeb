using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Graduate
    {   //Выпускник
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="ФИО")]
        public string FIO { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int ScienceWorkId { get; set; }
        public ScienceWork ScienceWork { get; set; }

    }
}