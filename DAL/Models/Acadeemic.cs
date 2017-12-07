using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Acadeemic
    {   //Академик
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public Acadeemic()
        {
            Teachers = new List<Teacher>();

        }
    }
}