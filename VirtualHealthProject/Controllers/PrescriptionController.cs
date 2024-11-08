using System.IO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;

public class PrescriptionController : Controller
{


    private readonly VirtualHealthDbContext _context;

    public PrescriptionController(VirtualHealthDbContext context)
    {
        _context = context;
    }

    // GET: Prescription
    public async Task<IActionResult> Index()
    {
        return View(await _context.Prescription.ToListAsync());
    }

    // GET: Prescription/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var prescription = await _context.Prescription
            .FirstOrDefaultAsync(m => m.PatientId == id);
        if (prescription == null)
        {
            return NotFound();
        }

        return View(prescription);
    }

    // GET: Prescription/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Prescription/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PatientId,FirstName, LastName, DOB, DateRecorded, Rx, Dispense, Rf, ExpDate, Notes")] Prescription prescription)
    {
        if (ModelState.IsValid)
        {
            _context.Add(prescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(prescription);
    }

    // GET: Prescription/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var prescription = await _context.Prescription.FindAsync(id);
        if (prescription == null)
        {
            return NotFound();
        }
        return View(prescription);
    }

    // POST: Prescription/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("PatientId,PatientID,DoctorID,Medication,Dosage,DateWritten,Status,DateForwardedToPharmacy,DateDeliveredToWard")] Prescription prescription)
    {
        if (id != prescription.PatientId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(prescription);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!prescriptionExists(prescription.PatientId))
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
        return View(prescription);
    }

    // GET: Prescription/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var prescription = await _context.Prescription
            .FirstOrDefaultAsync(m => m.PatientId == id);
        if (prescription == null)
        {
            return NotFound();
        }

        return View(prescription);
    }

    // POST: Prescription/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var prescription = await _context.Prescription.FindAsync(id);
        if (prescription != null)
        {
            _context.Prescription.Remove(prescription);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool prescriptionExists(int id)
    {
        return _context.Prescription.Any(e => e.PatientId == id);
    }






    [HttpGet]
    public IActionResult AddPrescription()
    {
        // Optionally, pass a model to prefill certain fields like PatientId, FirstName, LastName
        return View();
    }

    // Handle the form submission for recording a prescription
    [HttpPost]
    public IActionResult PrescriptionView(Prescription model)
    {
        if (ModelState.IsValid)
        {
            // Save the prescription to your database
            // Example (replace with your actual DB logic):
            // _dbContext.Prescriptions.Add(model);
            // _dbContext.SaveChanges();

            // Redirect to the PrescriptionView page to see all recorded prescriptions
            return RedirectToAction("PrescriptionView");
        }

        return View(model);
    }

    // Display the list of prescriptions
    [HttpPost]
    public IActionResult PrescriptionView()
    {
        // Retrieve the list of prescriptions from the database
        // Example (replace with your actual DB logic):
        // var prescriptions = _dbContext.Prescriptions.ToList();
        List<Prescription> prescriptions = new List<Prescription>(); // Replace with real data

        return View(prescriptions);
    }





































}
