using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Degree
    {   //Ученная степень
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public Degree()
        {
            Teachers = new List<Teacher>();

        }
    }
}