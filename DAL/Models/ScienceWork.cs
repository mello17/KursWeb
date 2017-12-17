using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class ScienceWork
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Theme { get; set; }
        [Required]
        [MaxLength(150)]
        public string ScienceDirection { get; set; }

        public Graduate Graduate { get; set; }
    }
}