using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EducationMVC.Data;
using EducationMVC.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace EducationMVC.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EducationMVCContext(serviceProvider.GetRequiredService<DbContextOptions<EducationMVCContext>>()))
            {
                if (context.Course.Any() || context.Student.Any() || context.Teacher.Any()) 
                {
                    return;
                }
                context.Student.AddRange(
                    new Student { /*Id = 1,*/ StudentId = "101", FirstName = "Vladimir",    LastName = "Krstikj",   EnrollmentDate = DateTime.Parse("2017-2-1"), AcquiredCredits = 200, CurrentSemester = 6, EducationLevel = "Diploma", ProfilePicture = "", Document = "" },
                    new Student { /*Id = 2,*/ StudentId = "102", FirstName = "Stojan",      LastName = "Nebiten",   EnrollmentDate = DateTime.Parse("2017-2-2"), AcquiredCredits = 105, CurrentSemester = 4, EducationLevel = "Diploma", ProfilePicture = "", Document = "" },
                    new Student { /*Id = 3,*/ StudentId = "103", FirstName = "Arthur",      LastName = "What",      EnrollmentDate = DateTime.Parse("2017-2-3"), AcquiredCredits = 140, CurrentSemester = 2, EducationLevel = "Diploma", ProfilePicture = "", Document = "" },
                    new Student { /*Id = 1,*/ StudentId = "104", FirstName = "Blabla",      LastName = "Ne znam",   EnrollmentDate = DateTime.Parse("2017-2-4"), AcquiredCredits = 50,  CurrentSemester = 2, EducationLevel = "Diploma", ProfilePicture = "", Document = "" },
                    new Student { /*Id = 1,*/ StudentId = "105", FirstName = "Fico",        LastName = "Lino",      EnrollmentDate = DateTime.Parse("2017-2-5"), AcquiredCredits = 75,  CurrentSemester = 4, EducationLevel = "Diploma", ProfilePicture = "", Document = "" }
                    );
                context.SaveChanges();

                context.Teacher.AddRange(
                    new Teacher { /*Id = 1,*/ FirstName = "Aneta",      LastName = "Buchkovska",    AcademicRank = "Professor",     Degree = "PhD", HireDate = DateTime.Parse("2017-1-1"), OfficeNumber = "1001", ProfilePicture = "aneta.jpeg" },
                    new Teacher { /*Id = 2,*/ FirstName = "Sanja",      LastName = "Atanasovska",   AcademicRank = "Alumni",        Degree = "PhD", HireDate = DateTime.Parse("2017-1-2"), OfficeNumber = "1002", ProfilePicture = "sanja.jpeg" },
                    new Teacher { /*Id = 3,*/ FirstName = "Margarita",  LastName = "Ginovska",      AcademicRank = "Professor",     Degree = "PhD", HireDate = DateTime.Parse("2017-1-3"), OfficeNumber = "1003", ProfilePicture = "margarita.jpeg" },
                    new Teacher { /*Id = 4,*/ FirstName = "Lihnida",    LastName = "Stojanovska",   AcademicRank = "Professor",     Degree = "PhD", HireDate = DateTime.Parse("2017-1-4"), OfficeNumber = "1004", ProfilePicture = "lihnida.jpeg" },
                    new Teacher { /*Id = 5,*/ FirstName = "Daniel",     LastName = "Denkovski",     AcademicRank = "Professor",     Degree = "PhD", HireDate = DateTime.Parse("2017-1-5"), OfficeNumber = "1005", ProfilePicture = "daniel.jpeg" },
                    new Teacher { /*Id = 6,*/ FirstName = "Anton",      LastName = "Chausheski",    AcademicRank = "Professor",     Degree = "PhD", HireDate = DateTime.Parse("2017-1-6"), OfficeNumber = "1006", ProfilePicture = "anton.jpeg" },
                    new Teacher { /*Id = 7,*/ FirstName = "Katerina",   LastName = "Raleva",        AcademicRank = "Alumni",        Degree = "MS",  HireDate = DateTime.Parse("2017-1-7"), OfficeNumber = "1007", ProfilePicture = "katerina.jpeg" },
                    new Teacher { /*Id = 8,*/ FirstName = "Tomislav",   LastName = "Kartalov",      AcademicRank = "Gospod",        Degree = "BOG", HireDate = DateTime.Parse("2017-1-8"), OfficeNumber = "1008", ProfilePicture = "tomislav.jpeg" }
                    );
                context.SaveChanges();

                context.Course.AddRange(
                    new Course { /*Id = 1,*/ Title = "Math 1",          Credits = 7, Semester = 1, Programme = "ALL",               EducationLevel = "8", FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Aneta" && d.LastName == "Buchkovska").Id,    SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Sanja" && d.LastName == "Atanasovska").Id },
                    new Course { /*Id = 2,*/ Title = "Physics 1",       Credits = 7, Semester = 1, Programme = "All",               EducationLevel = "7", FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Margarita" && d.LastName == "Ginovska").Id,  SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Lihnida" && d.LastName == "Stojanovska").Id },
                    new Course { /*Id = 3,*/ Title = "Java Dev",        Credits = 5, Semester = 2, Programme = "Computer Science",  EducationLevel = "9", FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Daniel" && d.LastName == "Denkovski").Id,    SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Katerina" && d.LastName == "Raleva").Id },
                    new Course { /*Id = 4,*/ Title = "C# Course",       Credits = 5, Semester = 3, Programme = "Computer Science",  EducationLevel = "8", FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Katerina" && d.LastName == "Raleva").Id,       SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Daniel" && d.LastName == "Denkovski").Id },
                    new Course { /*Id = 5,*/ Title = "Electronics 1",   Credits = 7, Semester = 4, Programme = "Hardware",          EducationLevel = "2", FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Tomislav" && d.LastName == "Kartalov").Id,   SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Lihnida" && d.LastName == "Stojanovska").Id },
                    new Course { /*Id = 6,*/ Title = "Ethical Hacking", Credits = 6, Semester = 7, Programme = "All",               EducationLevel = "2", FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Aneta" && d.LastName == "Buchkovska").Id,    SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Sanja" && d.LastName == "Atanasovska").Id }
                    );
                context.SaveChanges();

                context.Enrollment.AddRange(
                    new Enrollment 
                    { /*Id = 1, */
                        StudentId = context.Student.Single(d => d.StudentId == "101").Id,
                        CourseId = context.Course.Single(d => d.Title == "Math 1").Id,
                        Semester = "1", 
                        Year = 2017, 
                        Grade = 5, 
                        SeminalUrl = "www.google.com", 
                        ProjectUrl = "www.google.com", 
                        ExamPoints = 40, 
                        SeminalPoints = 20, 
                        ProjectPoints = 10, 
                        AdditionalPoints = 5, 
                        FinishDate = DateTime.Parse("2017-3-1") 
                    },
                    new Enrollment
                    { /*Id = 2,*/
                        StudentId = context.Student.Single(d => d.StudentId == "101").Id,
                        CourseId = context.Course.Single(d => d.Title == "Physics 1").Id,
                        Semester = "2",
                        Year = 2018,
                        Grade = 6,
                        SeminalUrl = "www.google.com",
                        ProjectUrl = "www.google.com",
                        ExamPoints = 40,
                        SeminalPoints = 20,
                        ProjectPoints = 10,
                        AdditionalPoints = 5,
                        FinishDate = DateTime.Parse("2017-3-1")
                    },
                    new Enrollment
                    { /*Id = 2,*/
                        StudentId = context.Student.Single(d => d.StudentId == "102").Id,
                        CourseId = context.Course.Single(d => d.Title == "Physics 1").Id,
                        Semester = "3",
                        Year = 2017,
                        Grade = 7,
                        SeminalUrl = "www.google.com",
                        ProjectUrl = "www.google.com",
                        ExamPoints = 40,
                        SeminalPoints = 20,
                        ProjectPoints = 10,
                        AdditionalPoints = 5,
                        FinishDate = DateTime.Parse("2017-3-1")
                    },
                    new Enrollment
                    { /*Id = 2,*/
                        StudentId = context.Student.Single(d => d.StudentId == "103").Id,
                        CourseId = context.Course.Single(d => d.Title == "Java Dev").Id,
                        Semester = "3",
                        Year = 2017,
                        Grade = 7,
                        SeminalUrl = "www.google.com",
                        ProjectUrl = "www.google.com",
                        ExamPoints = 40,
                        SeminalPoints = 20,
                        ProjectPoints = 10,
                        AdditionalPoints = 5,
                        FinishDate = DateTime.Parse("2017-3-1")
                    }


                    //new Enrollment { /*Id = 2,*/ CourseId = 2, StudentId = 102, Semester = "2", Year = 2017, Grade = 4, SeminalUrl = "www.google.com", ProjectUrl = "www.google.com", ExamPoints = 50, SeminalPoints = 10, ProjectPoints = 15, AdditionalPoints = 2, FinishDate = DateTime.Parse("2017-3-2") },
                    //new Enrollment { /*Id = 3,*/ CourseId = 3, StudentId = 103, Semester = "3", Year = 2017, Grade = 4, SeminalUrl = "www.google.com", ProjectUrl = "www.google.com", ExamPoints = 30, SeminalPoints = 20, ProjectPoints = 15, AdditionalPoints = 3, FinishDate = DateTime.Parse("2017-3-3") }
                );
                context.SaveChanges();

                context.User.AddRange(
                    new User
                    {
                        /*Id = 1,*/
                        Username = "admin",
                        Password = "root123",
                        Role = Role.Admin
                    },
                    new User
                    {
                        /*Id = 2,*/
                        Username = "profesor",
                        Password = "root123",
                        Role = Role.Teacher,
                        TeacherId = context.Teacher.Single(d => d.FirstName == "Aneta" && d.LastName == "Buchkovska").Id
                    },
                    new User
                    {
                        /*Id = 3,*/
                        Username = "student",
                        Password = "root123",
                        Role = Role.Student,
                        StudentId = context.Student.Single(d => d.FirstName == "Vladimir" && d.LastName == "Krstikj").Id
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
