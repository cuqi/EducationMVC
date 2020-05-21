using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationMVC.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }

        public string Role { get; set; }

        //if the user is a teacher
        public int? TeacherId { get; set; }

        [Display(Name = "Professor")]
        [NotMapped]
        public Teacher Teacher { get; set; }


        //if the user is a student
        public int? StudentId { get; set; }

        [Display(Name = "Student")]
        [NotMapped]
        public Student Student { get; set; }
    }
}
