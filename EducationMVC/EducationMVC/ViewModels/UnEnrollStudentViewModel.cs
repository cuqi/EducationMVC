using EducationMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EducationMVC.ViewModels
{
    public class UnEnrollStudentViewModel
    {
        public Course Course { get; set; }
        public SelectList CoursesList { get; set; }
        public IEnumerable<int?> SelectedStudents { get; set; }
        public IEnumerable<SelectListItem> StudentList { get; set; }

        [Display(Name = "Finish Date")]
        [DataType(DataType.Date)]
        public DateTime? FinishDate { get; set; }

        public int Year { get; set; }
        public string Semester { get; set; }

    }
}
