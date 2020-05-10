using EducationMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationMVC.ViewModels
{
    public class EnrollmentsFilterViewModel
    {
        public IList<Enrollment> Enrollments { get; set; }
        public IList<Course> Courses { get; set; }
        public SelectList Semester { get; set; }
        public int SearchYear { get; set; }
        public string SearchSemester { get; set; }
        public string SearchTitle { get; set; }
    }
}
