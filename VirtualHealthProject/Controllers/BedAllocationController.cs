using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace VirtualHealthProject.Controllers
{
    public class BedAllocationController : Controller
    {
        private readonly VirtualHealthDbContext _context;

        public BedAllocationController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        //This authorizes the user
        //[Authorize(Roles ="WardAdmin")]
        public async Task<IActionResult> Index()
        {
            var beds = from b in _context.Beds
                       join r in _context.Rooms on b.RoomID equals r.RoomID
                       join ba in _context.BedAllocations on b.BedID equals ba.BedID into bedAllocations
                       from ba in bedAllocations.DefaultIfEmpty()
                       join p in _context.Patients on ba.PatientID equals p.PatientID into patients
                       from p in patients.DefaultIfEmpty()
                       select new BedViewModel
                       {
                           BedID = b.BedID,
                           AllocatedTo = p != null ? p.FirstName + " " + p.LastName : "Not Allocated",
                           AllocationDate = ba.AllocationDate,
                           AvailabilityStatus = b.IsOccupied ? "Occupied" : "Available",

                           RoomNumber = r.RoomNumber
                       };

            var bedList = await beds.ToListAsync();

            // Calculate totals
            var totalBeds = bedList.Count;
            var availableBeds = bedList.Count(b => b.AvailabilityStatus == "Available");

            // Create a view model to pass data to the view
            var viewModel = new BedAllocationViewModel
            {
                Beds = bedList,
                TotalBeds = totalBeds,
                AvailableBeds = availableBeds
            };

            return View(viewModel);
        }

        // GET: BedAllocation/Create
        public IActionResult Create()
        {
            var model = new BedAllocationViewModel
            {
                RoomOptions = _context.Rooms.Select(r => new SelectListItem
                {
                    Value = r.RoomID.ToString(),
                    Text = r.RoomNumber
                }).ToList(),
                PatientOptions = _context.Patients.Select(p => new SelectListItem
                {
                    Value = p.PatientID.ToString(),
                    Text = $"{p.FirstName} {p.LastName}"
                }).ToList(),
                BedOptions = new List<SelectListItem>() // Initialize empty list
            };

            return View(model);
        }

        // POST: BedAllocation/Create
        [HttpPost]
        public async Task<IActionResult> Create(BedAllocationViewModel model)
        {
            // Ensure room selection is valid
            if (model.RoomID <= 0)
            {
                ModelState.AddModelError("", "Please select a valid room.");
                return await PopulateDropdowns(model);
            }

            // Populate available beds based on the selected room
            model.BedOptions = await _context.Beds
                .Where(b => b.RoomID == model.RoomID && !b.IsOccupied)
                .Select(b => new SelectListItem
                {
                    Value = b.BedID.ToString(),
                    Text = b.BedID.ToString() // Change as needed to show a more user-friendly bed description
                }).ToListAsync();

            // Validate selected bed
            if (model.SelectedBedID <= 0)
            {
                ModelState.AddModelError("", "Please select a valid bed.");
                return await PopulateDropdowns(model);
            }

            // Validate that the selected bed exists
            var bed = await _context.Beds.FindAsync(model.SelectedBedID);
            if (bed == null)
            {
                ModelState.AddModelError("", "Selected bed not found.");
                return await PopulateDropdowns(model);
            }

            // Validate the selected patient
            var patient = await _context.Patients.FindAsync(model.SelectedPatientID);
            if (patient == null)
            {
                ModelState.AddModelError("", "Selected patient not found.");
                return await PopulateDropdowns(model);
            }

            // Create allocation
            var allocation = new BedAllocation
            {
                BedID = model.SelectedBedID,
                PatientID = model.SelectedPatientID,
                RoomNumber = bed.RoomID.ToString(), // Ensure this aligns with your data model
                AllocationDate = DateTime.Now
            };

            // Mark the bed as occupied
            bed.IsOccupied = true;
            _context.BedAllocations.Add(allocation);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private async Task<IActionResult> PopulateDropdowns(BedAllocationViewModel model)
        {
            model.RoomOptions = await _context.Rooms.Select(r => new SelectListItem
            {
                Value = r.RoomID.ToString(),
                Text = r.RoomNumber
            }).ToListAsync();

            model.PatientOptions = await _context.Patients.Select(p => new SelectListItem
            {
                Value = p.PatientID.ToString(),
                Text = $"{p.FirstName} {p.LastName}"
            }).ToListAsync();

            // Ensure BedOptions are also populated if room is selected
            if (model.RoomID > 0)
            {
                model.BedOptions = await _context.Beds
                    .Where(b => b.RoomID == model.RoomID && !b.IsOccupied)
                    .Select(b => new SelectListItem
                    {
                        Value = b.BedID.ToString(),
                        Text = b.BedID.ToString() // Adjust if needed
                    }).ToListAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.BedAllocations.FindAsync(id);
            if (allocation == null)
            {
                return NotFound();
            }

            // Populate the view model with the allocation data
            var model = new BedAllocationViewModel
            {
                AllocationID = allocation.AllocationID,
                RoomNumber = allocation.RoomNumber,
                BedID = allocation.BedID,
                SelectedPatientID = allocation.PatientID,
                AllocationDate = allocation.AllocationDate,
                PatientOptions = await _context.Patients
                    .Select(p => new SelectListItem
                    {
                        Value = p.PatientID.ToString(),
                        Text = p.FirstName + " " + p.LastName
                    }).ToListAsync()
            };

            return View(model);
        }

        // POST: BedAllocation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllocationID,SelectedPatientID,AllocationDate")] BedAllocationViewModel model)
        {
            if (id != model.AllocationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var allocation = await _context.BedAllocations.FindAsync(id);
                    if (allocation == null)
                    {
                        return NotFound();
                    }

                    // Update the fields that can be changed
                    allocation.PatientID = model.SelectedPatientID;
                    allocation.AllocationDate = model.AllocationDate;

                    _context.Update(allocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BedAllocationExists(model.AllocationID))
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

            // If model state is invalid, repopulate PatientOptions and return the view
            model.PatientOptions = await _context.Patients
                .Select(p => new SelectListItem
                {
                    Value = p.PatientID.ToString(),
                    Text = p.FirstName + " " + p.LastName
                }).ToListAsync();

            return View(model);
        }

        private bool BedAllocationExists(int id)
        {
            return _context.BedAllocations.Any(e => e.AllocationID == id);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedDetails =await( from b in _context.Beds
                       join r in _context.Rooms on b.RoomID equals r.RoomID
                       join ba in _context.BedAllocations on b.BedID equals ba.BedID into bedAllocations
                       from ba in bedAllocations.DefaultIfEmpty()
                       join p in _context.Patients on ba.PatientID equals p.PatientID into patients
                       from p in patients.DefaultIfEmpty()
                       select new BedViewModel
                       {
                           BedID = b.BedID,
                           AllocatedTo = p != null ? p.FirstName + " " + p.LastName : "Not Allocated",
                           AllocationDate = ba.AllocationDate,
                           AvailabilityStatus = b.IsOccupied ? "Occupied" : "Available",

                           RoomNumber = r.RoomNumber
                       }).FirstOrDefaultAsync();

            if (bedDetails == null)
            {
                return NotFound();
            }

            return View(bedDetails); // Pass the specific BedViewModel to the view
       
        }


    }
}




