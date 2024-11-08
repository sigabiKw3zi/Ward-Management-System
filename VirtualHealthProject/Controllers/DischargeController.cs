using Microsoft.AspNetCore.Mvc;
using VirtualHealthProject.Models; // Adjust namespace as necessary
using VirtualHealthProject.ViewModels; // Adjust namespace as necessary
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualHealthProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace VirtualHealthProject.Controllers
{
    public class DischargeController : Controller
    {
        private readonly VirtualHealthDbContext _context; // Assuming you have a DbContext for EF Core

        public DischargeController(VirtualHealthDbContext context)
        {
            _context = context;
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        // GET: Discharge/Create
        // In the Create action method

        // GET: Discharge/Create
        public IActionResult Create()
        {
            var userId = GetUserId();
            var patients = _context.Patients
                .Select(p => new
                {
                    PatientId = p.PatientID,
                    FullName = p.FirstName + " " + p.LastName
                }).ToList();

            var users = _context.Users
      .Select(u => new
      {
          UserId = u.Id,
          FullName = u.FirstName + " " + u.LastName
      }).ToList();

            var viewModel = new DischargeViewModel
            {
                Patients = new SelectList(patients, "PatientId", "FullName"),
                Users = new SelectList(users, "UserId", "FullName")
            };

            return View(viewModel);
        }

        // POST: Discharge/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DischargeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var discharge = new Discharge
                {
                    DischargeDate = model.DischargeDate,
                    DischargeStatus = model.DischargeStatus,
                    PatientID = model.PatientId,
                    UserId = model.UserId,
                    CreatedDate = DateTime.Now
                };

                _context.Discharges.Add(discharge);
                _context.SaveChanges();

                return RedirectToAction(nameof(Confirmation)); // Redirect to index or list view
            }

            // Repopulate the view model on validation failure
            var patients = _context.Patients
                .Select(p => new
                {
                    PatientId = p.PatientID,
                    FullName = p.FirstName + " " + p.LastName
                }).ToList();

            var users = _context.Users
                .Select(u => new
                {
                    UserId = u.Id,
                    FullName = u.FirstName + " " + u.LastName
                }).ToList();

            model.Patients = new SelectList(patients, "PatientId", "FullName");
            model.Users = new SelectList(users, "UserId", "FullName");

            return View(model);
        }

        // GET: Discharge/Index
        public IActionResult Index()
        {
            var discharges = _context.Discharges
                .Include(d => d.Patient)
                .Include(d => d.User)
                .ToList();
            return View(discharges);
        }


        public async Task<IActionResult> ChangeStatus(int id)
        {
            var discharge = await _context.Discharges
           //.Include(d => d.Admission) // Include the Admission data
          .FirstOrDefaultAsync(d => d.DischargeId == id); // Fetch by DischargeId


            //var discharge = await _context.Discharges.FindAsync(id);
            if (discharge == null)
            {
                return NotFound();
            }

            // Ensure the status is only changed if it is currently "Pending"
            if (discharge.DischargeStatus == "Pending")
            {
                discharge.DischargeStatus = "Discharged";
                _context.Update(discharge);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index)); // Redirect to the index after status change
            }

            // Optionally handle the case where the status is not "Pending"
            return BadRequest("Status can only be changed from Pending to Discharged.");
        }

        public async Task<IActionResult> Details(int id)
        {
            var dischargeDetail = await _context.Discharges.FindAsync(id);

            if (dischargeDetail == null)
            {
                return NotFound(); // Handle case where the discharge detail is not found
            }

            var viewModel = new Discharge
            {
                User = dischargeDetail.User,
                Patient = dischargeDetail.Patient,
                DischargeDate = dischargeDetail.DischargeDate,
                DischargeStatus = dischargeDetail.DischargeStatus,
                CreatedDate = dischargeDetail.CreatedDate
            };

            return View(viewModel); // Return the view with the view model
        }
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _context.Discharges.FindAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            var discharge = new Discharge
            {
                DischargeId = viewModel.DischargeId,
                Patient = viewModel.Patient,
                DischargeStatus = viewModel.DischargeStatus,
                CreatedDate = viewModel.CreatedDate,
                DischargeDate = viewModel.DischargeDate
            };
            return View(discharge);
        }

        // POST: PatientMovement/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movement = await _context.PatientMovements.FindAsync(id);
            if (movement != null)
            {
                _context.PatientMovements.Remove(movement);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Confirmation()
        {
            return View();
        }

    }
}
