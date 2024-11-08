using Microsoft.AspNetCore.Mvc;
using VirtualHealthProject.Models;
using System.Collections.Generic;
using System.Linq;
using VirtualHealthProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VirtualHealthProject.Controllers
{
    public class RoomManagementController : Controller
    {
        private readonly VirtualHealthDbContext _context;
        public RoomManagementController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var beds = from b in _context.Beds
                       join r in _context.Rooms on b.RoomID equals r.RoomID // Join with Rooms table
                       join ba in _context.BedAllocations on b.BedID equals ba.BedID into bedAllocations
                       from ba in bedAllocations.DefaultIfEmpty()
                       join p in _context.Patients on ba.PatientID equals p.PatientID into patients
                       from p in patients.DefaultIfEmpty()
                       select new BedViewModel
                       {
                           BedID = b.BedID,
                           // Include other Bed properties as needed
                           AllocatedTo = p != null ? p.FirstName + " " + p.LastName : "Not Allocated",
                           AllocationDate = ba.AllocationDate,
                           AvailabilityStatus = b.IsOccupied ? "Occupied": "Available",

                           RoomNumber = r.RoomNumber // Fetch Room Number
                       };

            var bedList = await beds.ToListAsync();

            // Calculate totals
            var totalBeds = bedList.Count; // Changed from beds to bedList
            var availableBeds = bedList.Count(b => b.AvailabilityStatus == "Available");

            // Create a view model to pass data to the view
            var viewModel = new RoomManagementViewModel
            {
                Beds = bedList, // Change to appropriate type if needed
                TotalBeds = totalBeds,
                AvailableBeds = availableBeds
            };

            return View(viewModel);
        }

        public IActionResult Create(int bedId)
        {
            var model = new RoomManagementViewModel
            {
                SelectedBedId = bedId,
                Patients = _context.Patients.Select(p => new SelectListItem
                {
                    Value = p.PatientID.ToString(),
                    Text = $"{p.FirstName} {p.LastName}"
                }).ToList()
            };
            return View(model);
        }


        // POST: RoomManagement/Create
        [HttpPost]
        public IActionResult Create(RoomManagementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var bed = _context.Beds.FirstOrDefault(b => b.BedID == model.BedId);

                if (bed == null)
                {
                    return NotFound(); // Handle the error as needed
                }

               
                // Save the patient allocation
                var bedAllocation = new BedAllocation
                {
                    BedID = model.BedId,
                    PatientID = model.PatientID,
                    AllocationDate = model.AllocationDate
                };

                _context.BedAllocations.Add(bedAllocation);

                
                bed.IsOccupied = true; 

                _context.SaveChanges();

                return RedirectToAction("Index"); // or another appropriate action
            }

            // If model is not valid, repopulate the Patients list
            model.Patients = _context.Patients.Select(p => new SelectListItem
            {
                Value = p.PatientID.ToString(),
                Text = $"{p.FirstName} {p.LastName}"
            }).ToList();

            return View("Create",model);
        }
    }
}

