using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EducationMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationMVC.ViewModels
{
    public class EnrollStudentsViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<int?> SelectedStudents { get; set; }
        public IEnumerable<SelectListItem> StudentList { get; set; }
        public IEnumerable<int?> SelectedCourses { get; set; }
        public IEnumerable<SelectListItem> CoursesList { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }

    }
}
