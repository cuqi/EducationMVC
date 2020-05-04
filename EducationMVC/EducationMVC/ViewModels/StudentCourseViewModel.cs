using EducationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EducationMVC.ViewModels
{
    public class StudentCourseViewModel
    {
        public IList<Student> Students { get; set; }
        public string SearchStudentId { get; set; }
        public string SearchFirstName { get; set; }
        public string SearchLastName { get; set; }
    }
}
