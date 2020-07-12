using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Mgmt_System_MVC.Data;
using Student_Mgmt_System_MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Mgmt_System_MVC.Controllers
{
    public class Course_detailsController : Controller
    {
        private readonly Student_Mgmt_System_DB _context;

        public Course_detailsController(Student_Mgmt_System_DB context)
        {
            _context = context;
        }

        // GET: Course_details
        public async Task<IActionResult> Index()
        {
            return View(await _context.Course_details.ToListAsync());
        }

        // GET: Course_details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course_details = await _context.Course_details
                .FirstOrDefaultAsync(m => m.course_ID == id);
            if (course_details == null)
            {
                return NotFound();
            }

            return View(course_details);
        }
        [Authorize]
        // GET: Course_details/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Course_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("course_ID,course_Name,start_date,end_date,course_duration")] Course_details course_details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course_details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course_details);
        }
        [Authorize]
        // GET: Course_details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course_details = await _context.Course_details.FindAsync(id);
            if (course_details == null)
            {
                return NotFound();
            }
            return View(course_details);
        }
        [Authorize]
        // POST: Course_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("course_ID,course_Name,start_date,end_date,course_duration")] Course_details course_details)
        {
            if (id != course_details.course_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course_details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Course_detailsExists(course_details.course_ID))
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
            return View(course_details);
        }
        [Authorize]
        // GET: Course_details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course_details = await _context.Course_details
                .FirstOrDefaultAsync(m => m.course_ID == id);
            if (course_details == null)
            {
                return NotFound();
            }

            return View(course_details);
        }
        [Authorize]
        // POST: Course_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course_details = await _context.Course_details.FindAsync(id);
            _context.Course_details.Remove(course_details);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Course_detailsExists(int id)
        {
            return _context.Course_details.Any(e => e.course_ID == id);
        }
    }
}
