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
        [Display(Name ="Тема")]
        public string Theme { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name ="Научное направление")]
        public string ScienceDirection { get; set; }

        public ICollection<Graduate> Graduates { get; set; }
        public ScienceWork()
        {
            Graduates = new List<Graduate>();
        }
    }
}