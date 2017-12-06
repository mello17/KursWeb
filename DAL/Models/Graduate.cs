using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Graduate
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

    }
}