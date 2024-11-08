using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.Controllers
{
    public class ViewConsumablesStockController : Controller
    {
        private readonly VirtualHealthDbContext _context;
        public ViewConsumablesStockController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewConsumablesStock = _context.ConsumableStockLevels.Select(c => new ViewConsumablesStock
            {
                ConsumableId=c.ConsumableId,
                Name=c.Name,
                StockLevel=c.StockLevel,
                ReorderLevel=c.StockLevel,
                ExpirationDate=c.ExpirationDate
            }). ToList();
            return View(viewConsumablesStock);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewConsumablesStock = await _context.viewConsumablesStocks
                .FirstOrDefaultAsync(m => m.ConsumableId == id);
            if (viewConsumablesStock == null)
            {
                return NotFound();
            }

            return View(viewConsumablesStock);
        }
    }
}
