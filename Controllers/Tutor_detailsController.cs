using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Mgmt_System_MVC.Data;
using Student_Mgmt_System_MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Mgmt_System_MVC.Controllers
{
    public class Tutor_detailsController : Controller
    {
        private readonly Student_Mgmt_System_DB _context;

        public Tutor_detailsController(Student_Mgmt_System_DB context)
        {
            _context = context;
        }

        // GET: Tutor_details
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tutor_details.ToListAsync());
        }

        // GET: Tutor_details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor_details = await _context.Tutor_details
                .FirstOrDefaultAsync(m => m.tutor_ID == id);
            if (tutor_details == null)
            {
                return NotFound();
            }

            return View(tutor_details);
        }
        [Authorize]
        // GET: Tutor_details/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Tutor_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tutor_ID,tutor_Name,tutor_Email,tutor_Mobile,tutor_Address")] Tutor_details tutor_details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tutor_details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tutor_details);
        }
        [Authorize]
        // GET: Tutor_details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor_details = await _context.Tutor_details.FindAsync(id);
            if (tutor_details == null)
            {
                return NotFound();
            }
            return View(tutor_details);
        }
        [Authorize]
        // POST: Tutor_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tutor_ID,tutor_Name,tutor_Email,tutor_Mobile,tutor_Address")] Tutor_details tutor_details)
        {
            if (id != tutor_details.tutor_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutor_details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tutor_detailsExists(tutor_details.tutor_ID))
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
            return View(tutor_details);
        }
        [Authorize]
        // GET: Tutor_details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor_details = await _context.Tutor_details
                .FirstOrDefaultAsync(m => m.tutor_ID == id);
            if (tutor_details == null)
            {
                return NotFound();
            }

            return View(tutor_details);
        }
        [Authorize]
        // POST: Tutor_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tutor_details = await _context.Tutor_details.FindAsync(id);
            _context.Tutor_details.Remove(tutor_details);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tutor_detailsExists(int id)
        {
            return _context.Tutor_details.Any(e => e.tutor_ID == id);
        }
    }
}
