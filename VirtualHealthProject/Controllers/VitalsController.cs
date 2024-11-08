using System.IO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;

public class VitalsController : Controller
{
    private readonly VirtualHealthDbContext _context;

    public VitalsController(VirtualHealthDbContext context)
    {
        _context = context;
    }

    // GET: vitals
    public async Task<IActionResult> Index()
    {
        var vitalsList = await _context.Vitals.ToListAsync();
        return View(vitalsList);
    }

    // GET: vitals/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var vitals = await _context.Vitals.FirstOrDefaultAsync(m => m.VitalsId == id);
        if (vitals == null) return NotFound();

        return View(vitals);
    }
    //[HttpGet]
    //public IActionResult Create2()
    //{
    //    return View();
    //}

    //// POST: Vitals/Create
    //[HttpPost]
    //public async Task<IActionResult> Create2(Vitals vitals)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        await _context.Vitals.AddAsync(vitals);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    return View(vitals);
    //}
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST: Vitals/Create
    [HttpPost]
    public async Task<IActionResult> Create(Vitals vitals)
    {
        if (ModelState.IsValid)
        {
            await _context.Vitals.AddAsync(vitals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(vitals);
    }

    // GET: vitals/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var vitals = await _context.Vitals.FindAsync(id);
        if (vitals == null) return NotFound();

        return View(vitals);
    }

    // POST: vitals/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("VitalsId, Temperature, PulseRate, BloodPressure, PainLevel, ScheduleMedication, AdmissionDate, ScheduleIVMedications, ScheduleVMedications")] Vitals vitals)
    {
        if (id != vitals.VitalsId) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(vitals);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vitalsExists(vitals.VitalsId)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(vitals);
    }

    // GET: vitals/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var vitals = await _context.Vitals.FirstOrDefaultAsync(m => m.VitalsId == id);
        if (vitals == null) return NotFound();

        return View(vitals);
    }

    // POST: vitals/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var vitals = await _context.Vitals.FindAsync(id);
        if (vitals != null)
        {
            _context.Vitals.Remove(vitals);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool vitalsExists(int id)
    {
        return _context.Vitals.Any(e => e.VitalsId == id);
    }
}
