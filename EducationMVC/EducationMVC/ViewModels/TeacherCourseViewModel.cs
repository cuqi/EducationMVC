using EducationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationMVC.ViewModels
{
    public class TeacherCourseViewModel
    {
        public Course Courses { get; set; }
        public Student Studets { get; set; }

        public IEnumerable<Student> StudentList { get; set; }

    }
}
