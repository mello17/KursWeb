using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Resources;
using DAL.Web.Site.Models;
using Kurs_project_web.Models;
//using WebUI.Resourses;

namespace Kurs_project_web.Models
{
    public class LangModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource.Resource),
                  ErrorMessageResourceName = "NameRequired")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "CountryRequired")]
        [Display(Name = "Country", ResourceType = typeof(Resources.Resource))]
        public string State { get; set; }
    }
}