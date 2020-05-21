using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace EducationMVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }


        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int AcquiredCredits { get; set; }

        public int CurrentSemester { get; set; }

        [StringLength(25)]
        public string EducationLevel { get; set; }

        public ICollection<Enrollment> Courses { get; set; }

        public string ProfilePicture { get; set; }

        public string Document { get; set; }
    }
}
