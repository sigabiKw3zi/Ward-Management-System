//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using VirtualHealthProject.Data;
//using VirtualHealthProject.Models;
//using VirtualHealthProject.ViewModels;

//namespace VirtualHealthProject.Controllers
//{
//    [Authorize]
//    public class DoctorVisitsController : Controller
//    {
//        private readonly VirtualHealthDbContext _context;

//        public DoctorVisitsController(VirtualHealthDbContext context)
//        {
//            _context = context;
//        }

//        private string GetUserId()
//        {
//            return User.FindFirstValue(ClaimTypes.NameIdentifier);
//        }

//        //public async Task<IActionResult> Index()
//        //{
//        //    var visits = await _context.DoctorVisits
//        //        .Include(v => v.Patients) // Assuming this is set up correctly
//        //        .Include(v => v.User)      // Include the User navigation property
//        //        .ToListAsync();

//        //    var viewModel = visits.Select(v => new DoctorVisitViewModel
//        //    {
//        //        VisitId = v.VisitId,
//        //        VisitDateTime = v.VisitDateTime,
//        //        Note = v.Note,
//        //        PatientFullName = v.Patients.FirstOrDefault(p => p.PatientID == v.PatientID)?.FullName,
//        //        UserFullName = v.User?.FullName,
//        //        PatientID = v.PatientID,
//        //        UserId = v.UserId,
//        //        Patients = new SelectList(new[] { v.Patients.FirstOrDefault() }, "PatientID", "FullName"), // Get the first patient
//        //        Users = new SelectList(new[] { v.User }, "Id", "FullName") // Get the user
//        //    });

//        //    return View(viewModel);
//        //}

//        public async Task<IActionResult> Index()
//        {
//            var visits = await _context.DoctorVisits
//                .Include(v => v.Patients) // Include the single Patient
//                .Include(v => v.Users)     // Include the User navigation property
//                .ToListAsync();

//            var viewModel = visits.Select(v => new DoctorVisitViewModel
//            {
//                VisitId = v.VisitsId,
//                VisitDateTime = v.VisitDateTime,
//                Note = v.Note,
//                //PatientFullName = $"{v.Patient.FirstName} {v.Patient.LastName}", // Ensure Patient navigation is included
//                //UserFullName = $"{v.User.FirstName} {v.User.LastName}", // Ensure User navigation is included
//                PatientID = v.PatientID,
//                UserId = v.UserId
//            });

//            return View(viewModel);
//        }



//        // GET: DoctorVisits/Create
//        //public async Task<IActionResult> Create()
//        //{
//        //    var userId = GetUserId();

//        //    var viewModel = new DoctorVisitViewModel
//        //    {
//        //        Patients = new SelectList(await _context.Patients
//        //    .Select(p => new
//        //    {
//        //        PatientID = p.PatientID,
//        //        FullName = $"{p.FirstName} {p.LastName}"
//        //    })
//        //    .ToListAsync(),
//        //    "PatientID", "FullName"),

//        //        Users = new SelectList(await _context.Users
//        //    .Select(u => new
//        //    {
//        //        Id = u.Id,
//        //        FullName = $"{u.FirstName} {u.LastName}"
//        //    })
//        //    .ToListAsync(),
//        //    "Id", "FullName")
//        //    };

//        //    return View(viewModel);
//        //}

//        //// POST: DoctorVisits/Create
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> Create(DoctorVisitViewModel viewModel)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        var doctorVisit = new DoctorVisit
//        //        {
//        //            VisitDateTime = viewModel.VisitDateTime,
//        //            Note = viewModel.Note,
//        //            PatientID = viewModel.PatientID,
//        //            UserId = viewModel.UserId
//        //        };

//        //        _context.Add(doctorVisit);
//        //        await _context.SaveChangesAsync();
//        //        return RedirectToAction(nameof(Index));
//        //    }

//        //    // Repopulate the dropdowns
//        //    viewModel.Patients = new SelectList(await _context.Patients
//        //   .Select(p => new
//        //    {
//        //     PatientID = p.PatientID,
//        //     FullName = $"{p.FirstName} {p.LastName}"
//        //     })
//        //     .ToListAsync(), "PatientID", "FullName");

//        //    viewModel.Users = new SelectList(await _context.Users
//        //        .Select(u => new
//        //        {
//        //            Id = u.Id,
//        //            FullName = $"{u.FirstName} {u.LastName}"
//        //        })
//        //        .ToListAsync(), "Id", "FullName");

//        //    return View(viewModel);
//        //}


//        public async Task<IActionResult> Create()
//        {
//            var viewModel = new DoctorVisitViewModel
//            {
//                Patients = new SelectList(await _context.Patients
//                    .Select(p => new
//                    {
//                        PatientID = p.PatientID,
//                        FullName = $"{p.FirstName} {p.LastName}"
//                    })
//                    .ToListAsync(), "PatientID", "FullName"),

//                Users = new SelectList(await _context.Users
//                    .Select(u => new
//                    {
//                        Id = u.Id,
//                        FullName = $"{u.FirstName} {u.LastName}"
//                    })
//                    .ToListAsync(), "Id", "FullName")
//            };

//            return View(viewModel);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(DoctorVisitViewModel viewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                var doctorVisit = new DoctorVisit
//                {
//                    VisitDateTime = viewModel.VisitDateTime,
//                    Note = viewModel.Note,
//                    PatientID = viewModel.PatientID,
//                    UserId = viewModel.UserId
//                };

//                _context.Add(doctorVisit);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            // Repopulate dropdowns on error
//            viewModel.Patients = new SelectList(await _context.Patients
//                .Select(p => new
//                {
//                    PatientID = p.PatientID,
//                    FullName = $"{p.FirstName} {p.LastName}"
//                })
//                .ToListAsync(), "PatientID", "FullName");

//            viewModel.Users = new SelectList(await _context.Users
//                .Select(u => new
//                {
//                    Id = u.Id,
//                    FullName = $"{u.FirstName} {u.LastName}"
//                })
//                .ToListAsync(), "Id", "FullName");

//            return View(viewModel);
//        }

//        // GET: DoctorVisits/Edit/5
//        public async Task<IActionResult> Edit(int id)
//        {
//            var doctorVisit = await _context.DoctorVisits.FindAsync(id);
//            if (doctorVisit == null)
//            {
//                return NotFound();
//            }

//            var viewModel = new DoctorVisitViewModel
//            {
//                VisitId = doctorVisit.VisitsId,
//                VisitDateTime = doctorVisit.VisitDateTime,
//                Note = doctorVisit.Note,
//                PatientID = doctorVisit.PatientID,
//                UserId = doctorVisit.UserId,
//                Patients = new SelectList(await _context.Patients.ToListAsync(), "PatientID", "FirstName", "LastName"),
//                Users = new SelectList(await _context.Users.ToListAsync(), "Id", "FirstName", "LastName")
//            };

//            return View(viewModel);
//        }

//        // POST: DoctorVisits/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, DoctorVisitViewModel viewModel)
//        {
//            if (id != viewModel.VisitId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    var doctorVisit = await _context.DoctorVisits.FindAsync(id);
//                    if (doctorVisit == null)
//                    {
//                        return NotFound();
//                    }

//                    // Map ViewModel back to the model
//                    doctorVisit.VisitDateTime = viewModel.VisitDateTime;
//                    doctorVisit.Note = viewModel.Note;
//                    doctorVisit.PatientID = viewModel.PatientID;
//                    doctorVisit.UserId = viewModel.UserId;

//                    _context.Update(doctorVisit);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!DoctorVisitExists(viewModel.VisitId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }

//            // Repopulate dropdowns if model state is invalid
//            viewModel.Patients = new SelectList(await _context.Patients.ToListAsync(), "PatientID", "FirstName", "LastName");
//            viewModel.Users = new SelectList(await _context.Users.ToListAsync(), "Id", "FirstName", "LastName");
//            return View(viewModel);
//        }

//        public IActionResult Calendar()
//        {
//            return View();
//        }

//        // GET: DoctorVisits/Delete/5
//        public async Task<IActionResult> Delete(int id)
//        {
//            var doctorVisit = await _context.DoctorVisits
//                .Include(d => d.Users)
//                .Include(d => d.Patients)
//                .FirstOrDefaultAsync(m => m.VisitsId == id);
//            if (doctorVisit == null)
//            {
//                return NotFound();
//            }

//            return View(doctorVisit);
//        }

//        // POST: DoctorVisits/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var doctorVisit = await _context.DoctorVisits.FindAsync(id);
//            if (doctorVisit != null)
//            {
//                _context.DoctorVisits.Remove(doctorVisit);
//                await _context.SaveChangesAsync();
//            }
//            return RedirectToAction(nameof(Index));
//        }

//        private bool DoctorVisitExists(int id)
//        {
//            return _context.DoctorVisits.Any(e => e.VisitsId == id);
//        }
//    }
//}

