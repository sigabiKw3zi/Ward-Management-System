using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.Controllers
{
    //[Route("/Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult OurServices()
        {
            return View();
        }
        public IActionResult MeetOurTeam()
        {
            return View();
        }
        public IActionResult PatientCare()
        {
            return View();
        }
        public IActionResult Administration()
        {
            return View();
        }
        public IActionResult ConScript()
        {
            return View();
        }

        //[Route("/DoctorPatient")]
        public IActionResult DoctorPatient()
        {
            return View();
        }

        public IActionResult PatientManagement()
        {
            return View();
        }
        public IActionResult PharmacyDash()
        {
            return View();
        }

        public IActionResult Script()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
