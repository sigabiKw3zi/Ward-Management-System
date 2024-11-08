using Microsoft.AspNetCore.Mvc;
using VirtualHealthProject.Models;
using VirtualHealthProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace VirtualHealthProject.Controllers
{
    public class ReferralController : Controller
    {
        private readonly VirtualHealthDbContext _context;
        public ReferralController(VirtualHealthDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var referrals = _context.ReferralLetters.ToList();
            return View(referrals);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DoctorName = "Dr. Johann Joubert";
            ViewBag.DoctorContact = "021-245-2345";
            ViewBag.DoctorEmail = "johann.joubert@virtualhealthbridge.com";
            ViewBag.DoctorAddress = "34 Russel Road Port Elizabeth 6001";
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReferralLetter model)
        {
            if (ModelState.IsValid)
            {
                _context.ReferralLetters.Add(model); // Adjust as per your context
                _context.SaveChanges();
                return RedirectToAction("Confirmation");
            }
            return View(model);
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var referral = _context.ReferralLetters.Find(id);
            if (referral == null)
            {
                return NotFound();
            }
            return View(referral);
        }
        // GET: Referral/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var referral = await _context.ReferralLetters.FindAsync(id);
            if (referral == null)
            {
                return NotFound();
            }

            var model = new ReferralLetter
            {
                ReferralID = referral.ReferralID,
                FirstName = referral.FirstName,
                LastName = referral.LastName,
                DateOfBirth = referral.DateOfBirth,
                ContactNumber = referral.ContactNumber,
                PrimaryConcern = referral.PrimaryConcern,
                CurrentMedications = referral.CurrentMedications,
                AppointmentDate = referral.AppointmentDate,
                AppointmentTime = referral.AppointmentTime
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReferralID,FirstName,LastName,DateOfBirth,ContactNumber,PrimaryConcern,CurrentMedications,AppointmentDate,AppointmentTime")] ReferralLetter model)
        {
            if (id != model.ReferralID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model); // Use the update method for the entire model
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferralLetterExists(model.ReferralID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Re-throw the exception for further handling
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // Helper method to check if the referral letter exists
        private bool ReferralLetterExists(int id)
        {
            return _context.ReferralLetters.Any(e => e.ReferralID == id);
        }

        // GET: Referral/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var referral = await _context.ReferralLetters.FindAsync(id);
            if (referral == null)
            {
                return NotFound();
            }

            var viewModel = new ReferralLetter
            {
                ReferralID = referral.ReferralID,
                FirstName = referral.FirstName,
                LastName = referral.LastName,
                DateOfBirth = referral.DateOfBirth,
                ContactNumber = referral.ContactNumber,
                PrimaryConcern = referral.PrimaryConcern,
                CurrentMedications = referral.CurrentMedications,
                AppointmentDate = referral.AppointmentDate,
                AppointmentTime = referral.AppointmentTime
            };

            return View(viewModel);
        }

        // POST: Referral/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referral = await _context.ReferralLetters.FindAsync(id);
            if (referral != null)
            {
                _context.ReferralLetters.Remove(referral);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

    


