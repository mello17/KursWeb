using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DAL.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Group_Name{ get; set; }
        public int Count_Of_Student { get; set; }
        public ICollection<Graduate> Graduates { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public Group()
        {
            Graduates = new List<Graduate>();
            Schedules = new List<Schedule>();
        }

    }
}