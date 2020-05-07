using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducationMVC.Data;
using EducationMVC.Models;
using EducationMVC.ViewModels;

using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace EducationMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly EducationMVCContext _context;
        private readonly IHostingEnvironment webHostEnvironment;

        public StudentsController(EducationMVCContext context, IHostingEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Students
        public async Task<IActionResult> Index(string SearchStudentId, string SearchFirstName, string SearchLastName)
        {
            IQueryable<Student> students = _context.Student.AsQueryable();
            if (!string.IsNullOrEmpty(SearchStudentId))
            {
                students = students.Where(s => s.StudentId.Contains(SearchStudentId));
            }
            if (!string.IsNullOrEmpty(SearchFirstName))
            {
                students = students.Where(s => s.FirstName.Contains(SearchFirstName));
            }
            if (!string.IsNullOrEmpty(SearchLastName))
            {
                students = students.Where(s => s.LastName.Contains(SearchLastName));
            }
            var studentCourseVM = new StudentCourseViewModel
            {
                Students = await students.ToListAsync()
            };
            return View(studentCourseVM);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,FirstName,LastName,EnrollmentDate,AcquiredCredits,CurrentSemester,EducationLevel,ProfilePicture")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,FirstName,LastName,EnrollmentDate,AcquiredCredits,CurrentSemester,EducationLevel,ProfilePicture")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Student student = new Student
                {
                    StudentId = model.StudentId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    AcquiredCredits = model.AcquiredCredits,
                    CurrentSemester = model.CurrentSemester,
                    EducationLevel = model.EducationLevel,
                    EnrollmentDate = model.EnrollmentDate,
                    ProfilePicture = uniqueFileName,
                };
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        private string UploadedFile(StudentViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ProfileImage.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
