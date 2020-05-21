using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationMVC.ViewModels
{
    public class AuthStudentEditViewModel
    {
        public string ProjectUrl { get; set; }
        public string PURL { get; set; }

        public IFormFile document { get; set; }
    }
}
