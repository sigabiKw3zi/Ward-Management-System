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
    public class ConsumableStockController : Controller
    {
        private readonly VirtualHealthDbContext _context;

        public ConsumableStockController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        // GET: ConsumableStock
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConsumableStockLevels.ToListAsync());
        }

        // GET: ConsumableStock/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumableStockLevels = await _context.ConsumableStockLevels
                .FirstOrDefaultAsync(m => m.ConsumableId == id);
            if (consumableStockLevels == null)
            {
                return NotFound();
            }

            return View(consumableStockLevels);
        }

        // GET: ConsumableStock/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConsumableStock/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsumableId,Name,StockLevel,ReorderLevel,ExpirationDate")] ConsumableStockLevels consumableStockLevels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumableStockLevels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consumableStockLevels);
        }

        // GET: ConsumableStock/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumableStockLevels = await _context.ConsumableStockLevels.FindAsync(id);
            if (consumableStockLevels == null)
            {
                return NotFound();
            }
            return View(consumableStockLevels);
        }

        // POST: ConsumableStock/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsumableId,Name,StockLevel,ReorderLevel,ExpirationDate")] ConsumableStockLevels consumableStockLevels)
        {
            if (id != consumableStockLevels.ConsumableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumableStockLevels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumableStockLevelsExists(consumableStockLevels.ConsumableId))
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
            return View(consumableStockLevels);
        }

        // GET: ConsumableStock/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumableStockLevels = await _context.ConsumableStockLevels
                .FirstOrDefaultAsync(m => m.ConsumableId == id);
            if (consumableStockLevels == null)
            {
                return NotFound();
            }

            return View(consumableStockLevels);
        }

        // POST: ConsumableStock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumableStockLevels = await _context.ConsumableStockLevels.FindAsync(id);
            if (consumableStockLevels != null)
            {
                _context.ConsumableStockLevels.Remove(consumableStockLevels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumableStockLevelsExists(int id)
        {
            return _context.ConsumableStockLevels.Any(e => e.ConsumableId == id);
        }
    }
}
