using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EducationMVC.Models;

namespace EducationMVC.ViewModels
{
    public class CourseTeacherViewModel
    {
        public IList<Course> Courses { get; set; }
        public string SearchTitle { get; set; }
        public string SearchSemester { get; set; }
        public string SearchProgramme { get; set; }

    }
}
