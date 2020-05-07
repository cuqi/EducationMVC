using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EducationMVC.ViewModels
{
    public class StudentViewModel
    {
        [Required(ErrorMessage = "Please enter student ID")]
        [Display(Name = "Student ID")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Acquired Credits")]
        public int AcquiredCredits { get; set; }

        [Required(ErrorMessage = "Please enter Current Semester")]
        public int CurrentSemester { get; set; }

        [Required(ErrorMessage = "Please enter Education Level")]
        [Display(Name = "Education Level")]
        public string EducationLevel { get; set; }


        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }

        [Required(ErrorMessage = "Please choose Enrollment Date")]
        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

    }
}
