using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.Controllers
{
    public class NurseDispenseController : Controller
    {
        private readonly VirtualHealthDbContext _context;

        public NurseDispenseController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        // GET: NurseDispenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.NurseDispense.ToListAsync());
        }

        // GET: NurseDispenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurseDispense = await _context.NurseDispense
                .FirstOrDefaultAsync(m => m.DispenceId == id);
            if (nurseDispense == null)
            {
                return NotFound();
            }

            return View(nurseDispense);
        }

        // GET: nurseDispenses/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DispenceId,ScheduledMedication,PatientName,DatePrescribed,MedicineName,Quantity,Dosage")] NurseDispense nurseDispense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nurseDispense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nurseDispense);
        }

        // GET: nurseDispenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurseDispense = await _context.NurseDispense.FindAsync(id);
            if (nurseDispense == null)
            {
                return NotFound();
            }
            return View(nurseDispense);
        }

        // POST: nurseDispenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DispenceId,ScheduledMedication,PatientName,DatePrescribed,MedicineName,Quantity,Dosage")] NurseDispense nurseDispense)
        {

            if (id != nurseDispense.DispenceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nurseDispense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NurseDispenseExists(nurseDispense.DispenceId))
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
            return View(nurseDispense);
        }

        // GET: nurseDispenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurseDispense = await _context.NurseDispense
                .FirstOrDefaultAsync(m => m.DispenceId == id);
            if (nurseDispense == null)
            {
                return NotFound();
            }

            return View(nurseDispense);
        }

        // POST: nurseDispenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nurseDispense = await _context.NurseDispense.FindAsync(id);
            if (nurseDispense != null)
            {
                _context.NurseDispense.Remove(nurseDispense);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NurseDispenseExists(int id)
        {
            return _context.NurseDispense.Any(e => e.DispenceId == id);
        }
    }
}

