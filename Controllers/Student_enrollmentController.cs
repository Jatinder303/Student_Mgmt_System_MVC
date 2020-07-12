using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Mgmt_System_MVC.Data;
using Student_Mgmt_System_MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Mgmt_System_MVC.Controllers
{
    [Authorize]
    public class Student_enrollmentController : Controller
    {
        private readonly Student_Mgmt_System_DB _context;

        public Student_enrollmentController(Student_Mgmt_System_DB context)
        {
            _context = context;
        }

        // GET: Student_enrollment
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student_enrollment.ToListAsync());
        }

        // GET: Student_enrollment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_enrollment = await _context.Student_enrollment
                .FirstOrDefaultAsync(m => m.Student_Enrollment_ID == id);
            if (student_enrollment == null)
            {
                return NotFound();
            }

            return View(student_enrollment);
        }

        // GET: Student_enrollment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student_enrollment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Student_Enrollment_ID,student_ID,course_ID,tutor_ID")] Student_enrollment student_enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student_enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student_enrollment);
        }

        // GET: Student_enrollment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_enrollment = await _context.Student_enrollment.FindAsync(id);
            if (student_enrollment == null)
            {
                return NotFound();
            }
            return View(student_enrollment);
        }

        // POST: Student_enrollment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Student_Enrollment_ID,student_ID,course_ID,tutor_ID")] Student_enrollment student_enrollment)
        {
            if (id != student_enrollment.Student_Enrollment_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student_enrollmentExists(student_enrollment.Student_Enrollment_ID))
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
            return View(student_enrollment);
        }

        // GET: Student_enrollment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_enrollment = await _context.Student_enrollment
                .FirstOrDefaultAsync(m => m.Student_Enrollment_ID == id);
            if (student_enrollment == null)
            {
                return NotFound();
            }

            return View(student_enrollment);
        }

        // POST: Student_enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student_enrollment = await _context.Student_enrollment.FindAsync(id);
            _context.Student_enrollment.Remove(student_enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student_enrollmentExists(int id)
        {
            return _context.Student_enrollment.Any(e => e.Student_Enrollment_ID == id);
        }
    }
}
