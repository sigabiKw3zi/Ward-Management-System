using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.Controllers
{
    public class PatientMovementController : Controller
    {
        private readonly VirtualHealthDbContext _context;

        public PatientMovementController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        // GET: PatientMovement
        public async Task<IActionResult> Index()
        {
            var movements = await _context.PatientMovements
            .Include(m => m.Patient) // Ensure you're including the Patient if needed
            .ToListAsync();

            // Convert to ViewModel
            var viewModels = movements.Select(m => new PatientMovementViewModel
            {
                PatientMovementID = m.PatientMovementID,
                PatientID = m.PatientID,
                Movement = m.Movement,
                MovementTime = m.MovementTime,
                ReturnTime = m.ReturnTime,
              
            });

            return View(viewModels);
        }


        // GET: PatientMovement/Create
        public async Task<IActionResult> Create()
        {
            var model = new PatientMovementViewModel
            {
                PatientOptions = await _context.Patients
            .Select(p => new SelectListItem
            {
                Value = p.PatientID.ToString(),
                Text = p.FirstName + " " + p.LastName
            }).ToListAsync()
            };

            return View(model);
          
        }

        // POST: PatientMovement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientMovementViewModel model)
        {
                var patient = await _context.Patients.FindAsync(model.SelectedPatientID);
                if (patient == null)
                {
                    ModelState.AddModelError("", "Selected patient not found.");
                    return await PopulateDropdowns(model);
                   
                }

                var movement = new PatientMovement
                {
                    PatientID = model.SelectedPatientID,
                    Movement = model.Movement,
                    MovementTime = model.MovementTime,
                    ReturnTime = model.ReturnTime
                };

                _context.PatientMovements.Add(movement);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
        }

        private  async Task<IActionResult> PopulateDropdowns(PatientMovementViewModel model)
        {
            
                model.PatientOptions = await _context.Patients
                 .Select(p => new SelectListItem
                 {
                     Value = p.PatientID.ToString(),
                     Text = p.FirstName + " " + p.LastName
                 }).ToListAsync();
            
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movement = await _context.PatientMovements.FindAsync(id);
            if (movement == null)
            {
                return NotFound();
            }

            var model = new PatientMovementViewModel
            {
                PatientMovementID = movement.PatientMovementID, // Ensure this ID is populated
                SelectedPatientID = movement.PatientID,
                Movement = movement.Movement,
                MovementTime = movement.MovementTime,
                ReturnTime = movement.ReturnTime,
               PatientOptions = await GetPatientOptions() // Ensure this method populates patient options
            
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientMovementID,SelectedPatientID,Movement,MovementTime,ReturnTime")] PatientMovementViewModel model)
        {
            if (id != model.PatientMovementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var movement = await _context.PatientMovements.FindAsync(id);
                    if (movement == null)
                    {
                        return NotFound();
                    }

                    // Update the properties
                    movement.PatientID = model.SelectedPatientID;
                    movement.Movement = model.Movement;
                    movement.MovementTime = model.MovementTime;
                    movement.ReturnTime = model.ReturnTime;

                    _context.Update(movement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientMovementExists(model.PatientMovementID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Re-throw the exception for further handling
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // If the model state is invalid, repopulate necessary data for the view
            model.PatientOptions = await GetPatientOptions();
            return View(model);
        }

        // Helper method to check if the patient movement exists
        private bool PatientMovementExists(int id)
        {
            return _context.PatientMovements.Any(e => e.PatientMovementID == id);
        }

        // Method to get patient options for dropdown
        private async Task<List<SelectListItem>> GetPatientOptions()
        {
            return await _context.Patients
                .Select(p => new SelectListItem
                {
                    Value = p.PatientID.ToString(), // Assuming PatientID is an int or long
                    Text = $"{p.FirstName} {p.LastName}" // Concatenating first and last name for display
                })
                .ToListAsync(); // Fetch the data asynchronously
        }




        // GET: PatientMovement/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var movement = await _context.PatientMovements.FindAsync(id);
            if (movement == null)
            {
                return NotFound();
            }
            var viewModel = new PatientMovementViewModel
            {
                PatientMovementID = movement.PatientMovementID,
                PatientID = movement.PatientID,
               // PatientFullName=movement.PatientFullName,
                Movement = movement.Movement,
                MovementTime = movement.MovementTime,
                ReturnTime = movement.ReturnTime
            };
            return View(viewModel);
        }

        // POST: PatientMovement/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movement = await _context.PatientMovements.FindAsync(id);
            if (movement != null)
            {
                _context.PatientMovements.Remove(movement);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var movement = await _context.PatientMovements.FindAsync(id);
            if (movement == null)
            {
                return NotFound();
            }

            var model = new PatientMovementViewModel
            { 
                PatientMovementID= movement.PatientMovementID,
                SelectedPatientID = movement.PatientID,
                Movement = movement.Movement,
                MovementTime = movement.MovementTime,
                ReturnTime = movement.ReturnTime
                //PatientOptions = await GetPatientOptions() // Optional if you want to display the patient's name instead
            };

            return View(model);
        }

    }
}