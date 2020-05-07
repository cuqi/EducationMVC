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
        public int CourseId { get; set; }
        public IList<int> StudentsId { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
        public SelectList Courses { get; set; }
        public SelectList Students { get; set; }
   
    }
}
