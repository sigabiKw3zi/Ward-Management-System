using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.Controllers
{
    public class DispenceMedicationsController : Controller
    {
        private readonly VirtualHealthDbContext _context;

        public DispenceMedicationsController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        // GET: DispenceMedications
        public async Task<IActionResult> Index()
        {
            return View(await _context.DispenceMedication.ToListAsync());
        }

        // GET: DispenceMedications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispenceMedication = await _context.DispenceMedication
                .FirstOrDefaultAsync(m => m.DispenceId == id);
            if (dispenceMedication == null)
            {
                return NotFound();
            }

            return View(dispenceMedication);
        }

        // GET: DispenceMedications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DispenceMedications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DispenceId,FirstName,LastName,DateTime,MedicineName,Quantity,Notes")] DispenceMedication dispenceMedication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dispenceMedication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dispenceMedication);
        }

        // GET: DispenceMedications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispenceMedication = await _context.DispenceMedication.FindAsync(id);
            if (dispenceMedication == null)
            {
                return NotFound();
            }
            return View(dispenceMedication);
        }

        // POST: DispenceMedications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DispenceId,FirstName,LastName,DateTime,MedicineName,Quantity,Notes")] DispenceMedication dispenceMedication)
        {
            if (id != dispenceMedication.DispenceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dispenceMedication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DispenceMedicationExists(dispenceMedication.DispenceId))
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
            return View(dispenceMedication);
        }

        // GET: DispenceMedications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispenceMedication = await _context.DispenceMedication
                .FirstOrDefaultAsync(m => m.DispenceId == id);
            if (dispenceMedication == null)
            {
                return NotFound();
            }

            return View(dispenceMedication);
        }

        // POST: DispenceMedications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dispenceMedication = await _context.DispenceMedication.FindAsync(id);
            if (dispenceMedication != null)
            {
                _context.DispenceMedication.Remove(dispenceMedication);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DispenceMedicationExists(int id)
        {
            return _context.DispenceMedication.Any(e => e.DispenceId == id);
        }
    }
}
