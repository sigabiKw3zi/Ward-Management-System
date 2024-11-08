using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;
using System.Threading.Tasks;

namespace VirtualHealthProject.Controllers
{
    public class ScheduleVController : Controller
    {
        private readonly VirtualHealthDbContext _context;

        public ScheduleVController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        // GET: vitals
        public async Task<IActionResult> Index()
        {
            var vitals = await _context.Vitals.ToListAsync();
            return View(vitals);
        }

        // GET: vitals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vitals = await _context.Vitals.FindAsync(id);
            if (vitals == null)
            {
                return NotFound();
            }

            return View(vitals);
        }

        // GET: vitals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: vitals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            if (id == null)
            {
                return NotFound();
            }

            var vitals = await _context.Vitals.FindAsync(id);
            if (vitals == null)
            {
                return NotFound();
            }

            return View(vitals);
        }

        // POST: vitals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VitalsId, Temperature, PulseRate, BloodPressure, PainLevel, ScheduleMedication")] Vitals vitals)
        {
            if (id != vitals.VitalsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vitals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VitalsExists(vitals.VitalsId))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(vitals);
        }

        // GET: vitals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vitals = await _context.Vitals.FindAsync(id);
            if (vitals == null)
            {
                return NotFound();
            }

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

        private bool VitalsExists(int id)
        {
            return _context.Vitals.Any(e => e.VitalsId == id);
        }
    


























































































































        //private readonly VirtualHealthDbContext _context;

        //List<Vitals> vitals { get; set; }

        //public ScheduleVController(VirtualHealthDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: vitals
        ////public async Task<IActionResult> Index()
        ////{
        ////    return View(await _context.Vitals.ToListAsync());
        ////}




        //[HttpGet]
        //public IActionResult Index(Vitals model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}


        //// Display the list of vitals
        //[HttpPost]
        //public IActionResult Index()
        //{
        //    /*List<Vitals> vitals = new List<Vitals>();*/ // Replace with real data
        //    IEnumerable < Vitals> vitals = _context.Vitals;
        //    return View(vitals);
        //}






















        //// GET: vitals/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var vitals = await _context.Vitals
        //        .FirstOrDefaultAsync(m => m.VitalsId == id);
        //    if (vitals == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(vitals);
        //}

        //// GET: vitals/Create
        ////public IActionResult Create()
        ////{
        ////    return View();
        ////}

        ////// POST: vitals/Create
        ////// To protect from overposting attacks, enable the specific properties you want to bind to.
        ////// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public async Task<IActionResult> Create([Bind("PatientId,FirstName, LastName, AdmissionDate, CurrentMed, Temperature, PulseRate, BloodPressure, PainLevel, ScheduleMedication")] Vitals vitals)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        _context.Add(vitals);
        ////        await _context.SaveChangesAsync();
        ////        return RedirectToAction(nameof(Index));
        ////    }
        ////    return View(vitals);
        ////}



        //public IActionResult ScheduleV()
        //{
        //    return View();
        //}

        //// POST: Vitals/Create
        //[HttpPost]
        //public IActionResult ScheduleV(Vitals vitals)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Add the submitted data to the database (using your DbContext)
        //        _context.Vitals.Add(vitals);
        //        _context.SaveChanges();

        //        // Redirect to RecordedVitals view after successful submission
        //        return RedirectToAction("Index");
        //    }

        //    // If the model state is invalid, return to the same form with the data
        //    return View(vitals);
        //}




        //// GET: vitals/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var vitals = await _context.Vitals.FindAsync(id);
        //    if (vitals == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(vitals);
        //}

        //// POST: vitals/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("VitalsID, Temperature, PulseRate, BloodPressure, PainLevel, ScheduleMedication")] Vitals vitals)
        //{
        //    if (id != vitals.VitalsId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(vitals);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!vitalsExists(vitals.VitalsId))
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
        //    return View(vitals);
        //}

        //// GET: vitals/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var vitals = await _context.Vitals
        //        .FirstOrDefaultAsync(m => m.VitalsId == id);
        //    if (vitals == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(vitals);
        //}

        //// POST: vitals/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var vitals = await _context.Vitals.FindAsync(id);
        //    if (vitals != null)
        //    {
        //        _context.Vitals.Remove(vitals);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool vitalsExists(int id)
        //{
        //    return _context.Vitals.Any(e => e.VitalsId == id);
        //}







        ////[HttpGet]
        ////public IActionResult RecordedSVVitals(Vitals model)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        // Save the vitals to your database
        ////        // Example (replace with your actual DB logic):
        ////        // _dbContext.Vitals.Add(model);
        ////        // _dbContext.SaveChanges();
        ////        return RedirectToAction("RecordedSVVitals");
        ////    }

        ////    return View(model);
        ////}


        ////// Display the list of vitals
        ////[HttpPost]
        ////public IActionResult RecordedSVVitals()
        ////{
        ////    // Retrieve the list of vitals from the database
        ////    // Example (replace with your actual DB logic):
        ////    // var vitals = _dbContext.Vitals.ToList();
        ////    List<Vitals> vitals = new List<Vitals>(); // Replace with real data

        ////    return View(vitals);
        ////}



































        ////// Action to render the list
        ////public IActionResult SubmitVitals()
        ////{
        ////    var vitals = GetRecordedVitals(); // Fetch the list of vitals from your DB or source
        ////    return View(vitals);
        ////}


    }
}
