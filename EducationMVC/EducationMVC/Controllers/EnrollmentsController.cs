using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducationMVC.Data;
using EducationMVC.Models;
using EducationMVC.ViewModels;
using System.Collections.Immutable;

namespace EducationMVC.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly EducationMVCContext _context;

        public EnrollmentsController(EducationMVCContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index(string searchSemester, int? searchYear, string searchTitle)
        {
            IQueryable<Enrollment> enrollments = _context.Enrollment.AsQueryable();

            IQueryable<string> SemesterQuery = _context.Enrollment.OrderBy(s => s.Semester).Select(s => s.Semester).Distinct();
            IQueryable<int> YearQuery = _context.Enrollment.OrderBy(s => s.Year).Select(s => s.Year).Distinct();

            if(!string.IsNullOrEmpty(searchTitle))
            {
                enrollments = enrollments.Where(s => s.Course.Title.Contains(searchTitle));
            }
            if (!string.IsNullOrEmpty(searchSemester))
            {
                enrollments = enrollments.Where(s => s.Semester.Contains(searchSemester));
            }
            if (searchYear != null)
            {
                enrollments = enrollments.Where(s => s.Year == searchYear);
            }

            enrollments = enrollments.Include(s => s.Student).Include(s => s.Course);

            var enrollmentsFilterVM = new EnrollmentsFilterViewModel
            {
                Enrollments = await enrollments.ToListAsync(),
                Semester = new SelectList(await SemesterQuery.ToListAsync())
            };

            return View(enrollmentsFilterVM);
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,StudentId,Semester,Year,Grade,SeminalUrl,ProjectUrl,ExamPoints,SeminalPoints,ProjectPoints,AdditionalPoints,FinishDate")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName", enrollment.StudentId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,StudentId,Semester,Year,Grade,SeminalUrl,ProjectUrl,ExamPoints,SeminalPoints,ProjectPoints,AdditionalPoints,FinishDate")] Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollment.FindAsync(id);
            _context.Enrollment.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> EnrollStudents(int? id)
        {
            var course = _context.Course.Where(s => s.Id == id).Include(s => s.Students).First();

            if (course == null)
            {
                return NotFound();
            }

            var enrollStudentsVM = new EnrollStudentsViewModel
            {

                Course = course,
                /*CoursesList = new SelectList(_context.Course.OrderBy(s => s.Id), "Id", "Title"),*/
                StudentList = new MultiSelectList(_context.Student.OrderBy(s => s.Id), "Id", "FirstName"),
                SelectedStudents = course.Students.Select(s => s.StudentId),
            };


            return View(enrollStudentsVM);

            /*IQueryable<Course> courses = _context.Course;
            IQueryable<Student> students = _context.Student;
            string[] semesters = new[] { "Summer", "Winter" };
            int getYear = System.DateTime.Now.Year;
            int[] years = Enumerable.Range(getYear - 10, 11).Reverse().ToArray();
            var enrollStudentsViewModel = new EnrollStudentsViewModel
            {
                Courses = new SelectList(await courses.ToListAsync(), "Id", "Title"),
                Students = new SelectList(await students.OrderBy(s => s.FirstName).ToListAsync(), "Id", "FirstName"),
                Year = 100,
                Semester = "Leten"
            };

            return View(enrollStudentsViewModel);*/


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnrollStudents(int id, EnrollStudentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<int?> listStudents = model.SelectedStudents;
                    IQueryable<Enrollment> toBeRemoved = _context.Enrollment.Where(s => !listStudents.Contains(s.StudentId) && s.CourseId == id);
                    _context.Enrollment.RemoveRange(toBeRemoved);
                    IEnumerable<int?> existStudents = _context.Enrollment.Where(s => listStudents.Contains(s.StudentId) && s.CourseId == id).Select(s => s.StudentId);
                    IEnumerable<int?> newStudents = listStudents.Where(s => !existStudents.Contains(s));

                    foreach (int studentId in newStudents)
                        _context.Enrollment.Add(new Enrollment { StudentId = studentId, CourseId = id, Year = model.Year, Semester = model.Semester, });

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(CoursesController.Index));
            }
            return View(model);
        }

    }
}
