using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.Controllers
{
    public class BillingController : Controller
    {
        private readonly VirtualHealthDbContext _context;

        public BillingController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        // GET: NurseDispenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Billings.ToListAsync());
        }

        // GET: NurseDispenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billing = await _context.Billings
                .FirstOrDefaultAsync(m => m.BillId == id);
            if (billing == null)
            {
                return NotFound();
            }

            return View(billing);
        }

        // GET: nurseDispenses/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillId,ScheduledMedication,FirstName,LastName,AdmissionDate,DischargeDate,BedCharge,MedicationCharge,ServiceCharge,TotalAmount,AmountPaid,PaymentStatus,PaymentDate")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billing);
        }

        // GET: nurseDispenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billing = await _context.Billings.FindAsync(id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        // POST: nurseDispenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BillId,ScheduledMedication,FirstName,LastName,AdmissionDate,DischargeDate,BedCharge,MedicationCharge,ServiceCharge,TotalAmount,AmountPaid,PaymentStatus,PaymentDate")] Billing billing)
        {

            if (id != billing.BillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillingExists(billing.BillId))
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
            return View(billing);
        }

        // GET: nurseDispenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billing = await _context.Billings
                .FirstOrDefaultAsync(m => m.BillId == id);
            if (billing == null)
            {
                return NotFound();
            }

            return View(billing);
        }

        // POST: nurseDispenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billing = await _context.Billings.FindAsync(id);
            if (billing != null)
            {
                _context.Billings.Remove(billing);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillingExists(int id)
        {
            return _context.Billings.Any(e => e.BillId == id);
        }
    }
}

