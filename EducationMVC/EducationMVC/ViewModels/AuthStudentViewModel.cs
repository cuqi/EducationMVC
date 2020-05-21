using EducationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationMVC.ViewModels
{
    public class AuthStudentViewModel
    {
        public string nameStudent { get; set; }
        public Student Student { get; set; }
        public Enrollment Enrollment { get; set; }
        public Course Course { get; set; }
        public int? StudentId { get; set; }
        public IList<Student> StudentList { get; set; }
        public ICollection<Course> Courses { get; set; }


        // svoi predmeti, podatoci za predmetot: poeni ocenka i sl.
    }
}
