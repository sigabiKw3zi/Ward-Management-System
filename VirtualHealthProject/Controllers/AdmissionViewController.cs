using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.Controllers
{
    public class AdmissionViewController : Controller
    {

        private readonly VirtualHealthDbContext _context;

        public AdmissionViewController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var admits = await _context.Admissions
                .Include(a => a.Patient) // Include the Patient navigation property
                .ToListAsync(); // Await the asynchronous call

            var admission = admits.Select(admit => new AdmissionViewModel
            {
                PatientID = admit.PatientID,
                PatientName = admit.Patient.FirstName + " " + admit.Patient.LastName,
                AdmissionDate = admit.AdmissionDate,
                Status = admit.Status,
            }).ToList();

            return View(admission); // Return the list of view models
        }
    }
}
