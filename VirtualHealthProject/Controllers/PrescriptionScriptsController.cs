using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;
using VirtualHealthProject.ViewModels;

namespace VirtualHealthProject.Controllers
{
    [Authorize]
    public class PrescriptionScriptsController : Controller
    {
      
        private readonly VirtualHealthDbContext _context;

        public PrescriptionScriptsController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }


        // GET: PrescriptionScripts
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrescriptionScripts.ToListAsync());
        }

        // GET: PrescriptionScripts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescriptionScript = await _context.PrescriptionScripts
                .FirstOrDefaultAsync(m => m.PrescriptionID == id);
            if (prescriptionScript == null)
            {
                return NotFound();
            }

            return View(prescriptionScript);
        }

        // GET: PrescriptionScripts/Create
        public async Task<IActionResult> Create()
        {
            var userId = GetUserId(); // Your method to get current user (doctor) ID

            var model = new PrescriptionScriptViewModel
            {
                DateWritten = DateTime.Now, // Set current date by default
                PatientList = await _context.Patients
             .Select(p => new SelectListItem
             {
                 Value = p.PatientID.ToString(),
                 Text = $"{p.FirstName} {p.LastName}"
             })
             .ToListAsync(),
                DoctorList = await _context.Users
             .Select(d => new SelectListItem
             {
                 Value = d.Id.ToString(),
                 Text = $"{d.FirstName} {d.LastName}"
             })
             .ToListAsync(),
                UserId = userId // Set current logged-in doctor's ID
            };

            // Pass the PatientList to ViewBag for the dropdown
            ViewBag.Patients = model.PatientList;

            return View(model);
        }



        // POST: PrescriptionScripts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PrescriptionScriptViewModel model)
        {
            if (ModelState.IsValid)
            {
                var prescription = new PrescriptionScript
                {
                    PatientID = model.PatientID,
                    UserId = model.UserId,
                    Medication = model.Medication,
                    Dosage = model.Dosage,
                    DateWritten = model.DateWritten,
                    Status = model.Status,
                    DateForwardedToPharmacy = model.DateForwardedToPharmacy,
                    DateDeliveredToWard = model.DateDeliveredToWard
                };

                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Repopulate dropdowns if the model state is invalid
            model.PatientList = await _context.Patients
                .Select(p => new SelectListItem
                {
                    Value = p.PatientID.ToString(),
                    Text = $"{p.FirstName} {p.LastName}"
                })
                .ToListAsync();
            model.DoctorList = await _context.Users
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = $"{d.FirstName} {d.LastName}"
                })
                .ToListAsync();

            return View(model); // Return the same view with the current model to correct errors
        }



        // GET: PrescriptionScripts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescriptionScript = await _context.PrescriptionScripts.FindAsync(id);
            if (prescriptionScript == null)
            {
                return NotFound();
            }

            var model = new PrescriptionScriptViewModel
            {
                PrescriptionID = prescriptionScript.PrescriptionID,
                PatientID = prescriptionScript.PatientID,
                UserId = prescriptionScript.UserId,
                PatientList = await _context.Patients
                    .Select(p => new SelectListItem
                    {
                        Value = p.PatientID.ToString(),
                        Text = $"{p.FirstName} {p.LastName}"
                    })
                    .ToListAsync()
            };

            return View(model);
        }


        // POST: PrescriptionScripts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PrescriptionScript prescriptionScript)
        {
            if (id != prescriptionScript.PrescriptionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescriptionScript);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionScriptExists(prescriptionScript.PrescriptionID))
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

            // Repopulate the dropdown if the model state is invalid
            ViewBag.PatientList = await _context.Patients
                .Select(p => new SelectListItem
                {
                    Value = p.PatientID.ToString(),
                    Text = $"{p.FirstName} {p.LastName}"
                })
                .ToListAsync();

            return View(prescriptionScript);
        }

        // GET: PrescriptionScripts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescriptionScript = await _context.PrescriptionScripts
                .FirstOrDefaultAsync(m => m.PrescriptionID == id);
            if (prescriptionScript == null)
            {
                return NotFound();
            }

            return View(prescriptionScript);
        }

        // POST: PrescriptionScripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prescriptionScript = await _context.PrescriptionScripts.FindAsync(id);
            if (prescriptionScript != null)
            {
                _context.PrescriptionScripts.Remove(prescriptionScript);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionScriptExists(int id)
        {
            return _context.PrescriptionScripts.Any(e => e.PrescriptionID == id);
        }
    }
}
