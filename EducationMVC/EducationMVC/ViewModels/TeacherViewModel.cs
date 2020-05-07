using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace EducationMVC.ViewModels
{
    public class TeacherViewModel
    {
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "First Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter degree")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Please enter Academic Rank")]
        [Display(Name = "Academic rank")]
        public string AcademicRank { get; set; }

        [Required(ErrorMessage = "Please enter Office Number")]
        [Display(Name = "Office Number")]
        public string OfficeNumber { get; set; }

        [Required(ErrorMessage = "Please enter Hire Date")]
        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
