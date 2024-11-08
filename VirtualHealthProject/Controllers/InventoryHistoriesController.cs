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
    public class InventoryHistoriesController : Controller
    {
        private readonly VirtualHealthDbContext _context;

        public InventoryHistoriesController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        // GET: InventoryHistories
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventoryHistories.ToListAsync());
        }

        // GET: InventoryHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryHistory = await _context.InventoryHistories
                .FirstOrDefaultAsync(m => m.InventoryHistoryId == id);
            if (inventoryHistory == null)
            {
                return NotFound();
            }

            return View(inventoryHistory);
        }

        // GET: InventoryHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventoryHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryHistoryId,ConsumableId,MovementType,Quantity,MovementDate,Notes")] InventoryHistory inventoryHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryHistory);
        }

        // GET: InventoryHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryHistory = await _context.InventoryHistories.FindAsync(id);
            if (inventoryHistory == null)
            {
                return NotFound();
            }
            return View(inventoryHistory);
        }

        // POST: InventoryHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryHistoryId,ConsumableId,MovementType,Quantity,MovementDate,Notes")] InventoryHistory inventoryHistory)
        {
            if (id != inventoryHistory.InventoryHistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryHistoryExists(inventoryHistory.InventoryHistoryId))
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
            return View(inventoryHistory);
        }

        // GET: InventoryHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryHistory = await _context.InventoryHistories
                .FirstOrDefaultAsync(m => m.InventoryHistoryId == id);
            if (inventoryHistory == null)
            {
                return NotFound();
            }

            return View(inventoryHistory);
        }

        // POST: InventoryHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryHistory = await _context.InventoryHistories.FindAsync(id);
            if (inventoryHistory != null)
            {
                _context.InventoryHistories.Remove(inventoryHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryHistoryExists(int id)
        {
            return _context.InventoryHistories.Any(e => e.InventoryHistoryId == id);
        }
    }
}
