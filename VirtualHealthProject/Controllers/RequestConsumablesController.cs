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
    public class RequestConsumablesController : Controller
    {
        private readonly VirtualHealthDbContext _context;

        public RequestConsumablesController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        // GET: RequestConsumables
        public async Task<IActionResult> Index()
        {
            return View(await _context.RequestConsumables.ToListAsync());
        }

        // GET: RequestConsumables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestConsumables = await _context.RequestConsumables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestConsumables == null)
            {
                return NotFound();
            }

            return View(requestConsumables);
        }

        // GET: RequestConsumables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestConsumables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConsumableName,Notes,Quantity,Status,RequestDate")] RequestConsumables requestConsumables)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestConsumables);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestConsumables);
        }

        // GET: RequestConsumables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestConsumables = await _context.RequestConsumables.FindAsync(id);
            if (requestConsumables == null)
            {
                return NotFound();
            }
            return View(requestConsumables);
        }

        // POST: RequestConsumables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConsumableName,Notes,Quantity,Status,RequestDate")] RequestConsumables requestConsumables)
        {
            if (id != requestConsumables.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestConsumables);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestConsumablesExists(requestConsumables.Id))
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
            return View(requestConsumables);
        }

        // GET: RequestConsumables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestConsumables = await _context.RequestConsumables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestConsumables == null)
            {
                return NotFound();
            }

            return View(requestConsumables);
        }

        // POST: RequestConsumables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestConsumables = await _context.RequestConsumables.FindAsync(id);
            if (requestConsumables != null)
            {
                _context.RequestConsumables.Remove(requestConsumables);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestConsumablesExists(int id)
        {
            return _context.RequestConsumables.Any(e => e.Id == id);
        }
    }
}
