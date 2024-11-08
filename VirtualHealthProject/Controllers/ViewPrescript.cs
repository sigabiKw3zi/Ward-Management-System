using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.Controllers
{
    public class ViewPrescript : Controller
    {
        private readonly VirtualHealthDbContext _context;

        public ViewPrescript(VirtualHealthDbContext context)
        {
            _context = context;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }


        // GET: PrescriptionScripts
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrescriptionScripts.ToListAsync());
        }

    }
}
