using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Resources;
namespace Kurs_project_web.Models
{
    public class LangModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Resource_rus),
                  ErrorMessageResourceName = "NameRequired")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource_rus))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_rus),
                  ErrorMessageResourceName = "CountryRequired")]
        [Display(Name = "Country", ResourceType = typeof(Resources.Resource_rus))]
        public string State { get; set; }
        
    }
}