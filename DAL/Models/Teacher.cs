using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int AcademicId { get; set; }
        public Acadeemic Academic { get; set; }

        public ICollection<Group> Groups { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<Graduate> Graduates { get; set; }

        public Teacher()
        {
            Groups = new List<Group>();
            Jobs = new List<Job>();
            Graduates = new List<Graduate>();
        }
    }
}