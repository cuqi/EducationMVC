using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EducationMVC.Models;

namespace EducationMVC.Data
{
    public class EducationMVCContext : DbContext
    {
        public EducationMVCContext (DbContextOptions<EducationMVCContext> options)
            : base(options)
        {
        }

        public DbSet<EducationMVC.Models.Course> Course { get; set; }

        public DbSet<EducationMVC.Models.Student> Student { get; set; }

        public DbSet<EducationMVC.Models.Enrollment> Enrollment { get; set; }

        public DbSet<EducationMVC.Models.Teacher> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>()
                .HasOne<Teacher>(p => p.FirstTeacher)
                .WithMany(p => p.Professor)
                .HasForeignKey(p => p.FirstTeacherId);
            builder.Entity<Course>()
                .HasOne<Teacher>(p => p.SecondTeacher)
                .WithMany(p => p.Assistant)
                .HasForeignKey(p => p.SecondTeacherId);
            builder.Entity<Enrollment>()
                .HasOne<Course>(p => p.Course)
                .WithMany(p => p.Students)
                .HasForeignKey(p => p.CourseId);
            builder.Entity<Enrollment>()
                .HasOne<Student>(p => p.Student)
                .WithMany(p => p.Courses)
                .HasForeignKey(p => p.StudentId);
        }
    }
}
