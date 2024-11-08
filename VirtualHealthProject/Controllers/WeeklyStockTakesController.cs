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
    public class WeeklyStockTakesController : Controller
    {
        private readonly VirtualHealthDbContext _context;

        public WeeklyStockTakesController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        // GET: WeeklyStockTakes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeeklyStockTakes.ToListAsync());
        }

        // GET: WeeklyStockTakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklyStockTakes = await _context.WeeklyStockTakes
                .FirstOrDefaultAsync(m => m.StockTakeID == id);
            if (weeklyStockTakes == null)
            {
                return NotFound();
            }

            return View(weeklyStockTakes);
        }

        // GET: WeeklyStockTakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeeklyStockTakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockTakeID,ManagerName,DateTime,ConsumableName,AvailableStock,StockNeeded,Comment")] WeeklyStockTakes weeklyStockTakes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weeklyStockTakes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weeklyStockTakes);
        }

        // GET: WeeklyStockTakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklyStockTakes = await _context.WeeklyStockTakes.FindAsync(id);
            if (weeklyStockTakes == null)
            {
                return NotFound();
            }
            return View(weeklyStockTakes);
        }

        // POST: WeeklyStockTakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockTakeID,ManagerName,DateTime,ConsumableName,AvailableStock,StockNeeded,Comment")] WeeklyStockTakes weeklyStockTakes)
        {
            if (id != weeklyStockTakes.StockTakeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weeklyStockTakes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeeklyStockTakesExists(weeklyStockTakes.StockTakeID))
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
            return View(weeklyStockTakes);
        }

        // GET: WeeklyStockTakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklyStockTakes = await _context.WeeklyStockTakes
                .FirstOrDefaultAsync(m => m.StockTakeID == id);
            if (weeklyStockTakes == null)
            {
                return NotFound();
            }

            return View(weeklyStockTakes);
        }

        // POST: WeeklyStockTakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weeklyStockTakes = await _context.WeeklyStockTakes.FindAsync(id);
            if (weeklyStockTakes != null)
            {
                _context.WeeklyStockTakes.Remove(weeklyStockTakes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeeklyStockTakesExists(int id)
        {
            return _context.WeeklyStockTakes.Any(e => e.StockTakeID == id);
        }
    }
}
