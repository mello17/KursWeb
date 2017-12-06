using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime Time { get; set; }
        public string Auditory { get; set; }
    }
}