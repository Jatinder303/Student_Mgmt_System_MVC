using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Mgmt_System_MVC.Data;
using Student_Mgmt_System_MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Mgmt_System_MVC.Controllers
{
    public class student_DetailsController : Controller
    {
        private readonly Student_Mgmt_System_DB _context;

        public student_DetailsController(Student_Mgmt_System_DB context)
        {
            _context = context;
        }

        // GET: student_Details
        public async Task<IActionResult> Index()
        {
            return View(await _context.student_Details.ToListAsync());
        }

        // GET: student_Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Details = await _context.student_Details
                .FirstOrDefaultAsync(m => m.student_ID == id);
            if (student_Details == null)
            {
                return NotFound();
            }

            return View(student_Details);
        }

        [Authorize]
        // GET: student_Details/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: student_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("student_ID,student_Name,student_Email,student_Mobile,student_Address")] student_Details student_Details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student_Details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student_Details);
        }
        [Authorize]
        // GET: student_Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Details = await _context.student_Details.FindAsync(id);
            if (student_Details == null)
            {
                return NotFound();
            }
            return View(student_Details);
        }
        [Authorize]
        // POST: student_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("student_ID,student_Name,student_Email,student_Mobile,student_Address")] student_Details student_Details)
        {
            if (id != student_Details.student_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_Details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!student_DetailsExists(student_Details.student_ID))
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
            return View(student_Details);
        }
        [Authorize]
        // GET: student_Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Details = await _context.student_Details
                .FirstOrDefaultAsync(m => m.student_ID == id);
            if (student_Details == null)
            {
                return NotFound();
            }

            return View(student_Details);
        }
        [Authorize]
        // POST: student_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student_Details = await _context.student_Details.FindAsync(id);
            _context.student_Details.Remove(student_Details);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool student_DetailsExists(int id)
        {
            return _context.student_Details.Any(e => e.student_ID == id);
        }
    }
}
