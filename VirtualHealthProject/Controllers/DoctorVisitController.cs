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
    public class DoctorVisitController : Controller
    {

        private readonly VirtualHealthDbContext _context;
        public DoctorVisitController(VirtualHealthDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var doctorVisit = _context.DoctorVisit.ToList();
            return View(doctorVisit);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(DoctorVisit model)
        {
            if (ModelState.IsValid)
            {
                _context.DoctorVisit.Add(model); // Adjust as per your context
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
            var doctorVisit = _context.DoctorVisit.Find(id);
            if (doctorVisit == null)
            {
                return NotFound();
            }
            return View(doctorVisit);
        }
        // GET: Referral/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var doctorVisit = await _context.DoctorVisit.FindAsync(id);
            if (doctorVisit == null)
            {
                return NotFound();
            }

            var model = new DoctorVisit
            {
                VisitId = doctorVisit.VisitId,
                ScheduledMedication = doctorVisit.ScheduledMedication,
                ChronicConditions = doctorVisit.ChronicConditions,
                ScheduleIVMedication = doctorVisit.ScheduleIVMedication,
                ScheduleVMedication = doctorVisit.ScheduleVMedication,
                ChronicConditionsStatus = doctorVisit.ChronicConditionsStatus
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleMedication, ChronicConditions")] DoctorVisit model)
        {
            if (id != model.VisitId)
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
                    if (!DoctorVisitExists(model.VisitId))
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
        private bool DoctorVisitExists(int id)
        {
            return _context.DoctorVisit.Any(e => e.VisitId == id);
        }

        // GET: Referral/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var doctorVisit = await _context.DoctorVisit.FindAsync(id);
            if (doctorVisit == null)
            {
                return NotFound();
            }

            var viewModel = new DoctorVisit
            {
                VisitId = doctorVisit.VisitId,
                ScheduledMedication = doctorVisit.ScheduledMedication,
                ChronicConditions = doctorVisit.ChronicConditions,
                ScheduleIVMedication = doctorVisit.ScheduleIVMedication,
                ScheduleVMedication = doctorVisit.ScheduleVMedication,
                ChronicConditionsStatus = doctorVisit.ChronicConditionsStatus
            };

            return View(viewModel);
        }

        // POST: Referral/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorVisit = await _context.DoctorVisit.FindAsync(id);
            if (doctorVisit != null)
            {
                _context.DoctorVisit.Remove(doctorVisit);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }








































































































































































        //private readonly VirtualHealthDbContext _context;
        //List<Prescription> prep { get; set; }

        //public DoctorVisitController(VirtualHealthDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: DoctorVisit
        ////public async Task<IActionResult> Index()
        ////{
        ////    var virtualHealthDbContext = _context.DoctorVisit.Include(p => p.User);
        ////    return View(await virtualHealthDbContext.ToListAsync());
        ////}






        ////[HttpGet]
        ////public IActionResult Index()
        ////{
        ////    // Fetch the list of doctor visits from the database
        ////    IEnumerable<DoctorVisit> doctorVisit = _context.DoctorVisit.ToList();

        ////    // Pass the list to the view
        ////    return View(doctorVisit);
        ////}


        ////[HttpPost]
        ////public IActionResult Index(DoctorVisit model)
        ////{

        ////        _context.DoctorVisit.Add(model);
        ////        _context.SaveChanges();

        ////    return RedirectToAction("Index");


        ////    //return View(model);
        ////}

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.DoctorVisit.ToListAsync());
        //}


        //// GET: DoctorVisit/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var DoctorVisit = await _context.DoctorVisit
        //        .Include(p => p.User)
        //        .FirstOrDefaultAsync(m => m.VisitId == id);
        //    if (DoctorVisit == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(DoctorVisit);
        //}

        //// GET: DoctorVisit/Create
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    ViewData["VisitId"] = new SelectList(_context.Users, "Id", "Id");
        //    return View();
        //}

        //// POST: DoctorVisit/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public async Task<IActionResult> Create([Bind("ScheduleMedication, ChronicConditions, IsAdmitted, AdmissionDate, Notes, Prescription, Instruction")] DoctorVisit DoctorVisit)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        _context.Add(DoctorVisit);
        ////        await _context.SaveChangesAsync();
        ////        return RedirectToAction(nameof(Index));
        ////    }
        ////    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", DoctorVisit.UserId);
        ////    return View(DoctorVisit);
        ////}
        //[HttpPost]
        //public IActionResult Create(DoctorVisit doctorVisit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Add the submitted data to the database (using your DbContext)
        //        _context.DoctorVisit.Add(doctorVisit);
        //        _context.SaveChanges();

        //        // Redirect to PatientList view after successful submission
        //        return RedirectToAction("PatientList");
        //    }

        //    // If the model state is invalid, return to the same form with the data
        //    return View(doctorVisit);
        //}


        //// GET: DoctorVisit/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var DoctorVisit = await _context.DoctorVisit.FindAsync(id);
        //    if (DoctorVisit == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["VisitId"] = new SelectList(_context.Users, "Id", "Id", DoctorVisit.UserId);
        //    return View(DoctorVisit);
        //}

        //// POST: DoctorVisit/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("VisitId, ScheduleMedication, ChronicConditions, IsAdmitted, AdmissionDate, Notes, Prescription, Instruction")]  DoctorVisit DoctorVisit)
        //{
        //    if (id != DoctorVisit.VisitId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(DoctorVisit);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DoctorVisitExists(DoctorVisit.VisitId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["VisitId"] = new SelectList(_context.Users, "Id", "Id", DoctorVisit.VisitId);
        //    return View(DoctorVisit);
        //}

        //// GET: DoctorVisit/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var DoctorVisit = await _context.DoctorVisit
        //        .Include(p => p.User)
        //        .FirstOrDefaultAsync(m => m.VisitId == id);
        //    if (DoctorVisit == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(DoctorVisit);
        //}

        //// POST: DoctorVisit/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var DoctorVisit = await _context.DoctorVisit.FindAsync(id);
        //    if (DoctorVisit != null)
        //    {
        //        _context.DoctorVisit.Remove(DoctorVisit);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DoctorVisitExists(int id)
        //{
        //    return _context.DoctorVisit.Any(e => e.VisitId == id);
        //}


        //public IActionResult AddPrescription()
        //{
        //    Prescription prep = new Prescription();
        //    return View(prep);
        //}

        //// Custom action for instructions
        ////public IActionResult Instructions()
        ////{
        ////    return View();
        ////}

        //public IActionResult PrescriptionView(Prescription prescription)
        //{
        //    prep = new List<Prescription>();
        //    prep.Add(prescription);
        //    return View(prep);
        //}

        //public IActionResult SubmitPrescription()
        //{
        //    List<Prescription> prep = new List<Prescription>();
        //    return View(prep);
        //}

    }





}
