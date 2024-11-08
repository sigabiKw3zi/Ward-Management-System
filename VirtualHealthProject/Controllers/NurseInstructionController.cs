using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;
using VirtualHealthProject.ViewModels;

namespace VirtualHealthProject.Controllers
{
    [Authorize]
    public class NurseInstructionsController : Controller
    {
        private readonly VirtualHealthDbContext _context;

        public NurseInstructionsController(VirtualHealthDbContext context)
        {
            _context = context;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }


        private void PopulateDropdowns(InstructionViewModel instruction)
        {
            instruction.Patients = _context.Patients.Select(p => new SelectListItem
            {
                Value = p.PatientID.ToString(),
                Text = p.FirstName + " " + p.LastName
            }).ToList(); 

            instruction.Users = _context.Users.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.FirstName + " " + u.LastName
            }).ToList();
        }

        // GET: Instructions
        public async Task<IActionResult> Index()
        {
            var virtualHealthDbContext = _context.NurseInstructions.Include(i => i.Users);
            return View(await virtualHealthDbContext.ToListAsync());
        }

        // GET: Instructions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instruction = await _context.NurseInstructions
                .Include(i => i.Users)
                .FirstOrDefaultAsync(m => m.InstructionId == id);
            if (instruction == null)
            {
                return NotFound();
            }

            return View(instruction);
        }



        // GET: Instructions/Create
        public IActionResult Create()
        {
            var userId = GetUserId();
            // Create a new instance of the InstructionViewModel
            var instructionViewModel = new InstructionViewModel
            {

                Description = " ",
                CreatedDate = DateTime.Now,
                Remarks = " ",
                RemarkDate = DateTime.Now,
                UserId = " ",
                Status = " ",
            };

            // Populate dropdowns
            PopulateDropdowns(instructionViewModel);

            return View(instructionViewModel);
        }



        // POST: Instructions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructionId,Description,CreatedDate,Remarks,RemarkDate,UserId,PatientID,Status")] InstructionViewModel instructionViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var instructionview = new NurseInstruction // Assuming NurseInstruction is your entity
                    {
                        Description = instructionViewModel.Description,
                        CreatedDate = instructionViewModel.CreatedDate,
                        Remarks = instructionViewModel.Remarks,
                        RemarkDate = instructionViewModel.RemarkDate,
                        UserId = instructionViewModel.UserId,
                        PatientID = instructionViewModel.PatientID, // Add this line
                        Status = instructionViewModel.Status
                    };

                    _context.NurseInstructions.Add(instructionview);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Instruction created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the error (you might want to use a logging library)
                    ModelState.AddModelError("", "Unable to create instruction. Try again, and if the problem persists see your system administrator.");
                }
            }

            PopulateDropdowns(instructionViewModel);
            return View(instructionViewModel);
        }


        // GET: Instructions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instruction = await _context.NurseInstructions.FindAsync(id);
            if (instruction == null)
            {
                return NotFound();
            }

            var instructionViewModel = new InstructionViewModel
            {
                InstructionId = instruction.InstructionId,
                Description = instruction.Description,
                CreatedDate = instruction.CreatedDate,
                Remarks = instruction.Remarks,
                RemarkDate = instruction.RemarkDate,
                UserId = instruction.UserId,
                Status = instruction.Status
                // Map any other properties if needed
            };

            // Populate dropdowns
            PopulateDropdowns(instructionViewModel);

            return View(instruction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InstructionViewModel instructionViewModel)
        {
            if (id != instructionViewModel.InstructionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var instruction = await _context.NurseInstructions.FindAsync(id);
                    if (instruction == null)
                    {
                        return NotFound();
                    }

                    // Update the entity with new values
                    instruction.Description = instructionViewModel.Description;
                    instruction.CreatedDate = instructionViewModel.CreatedDate;
                    instruction.Remarks = instructionViewModel.Remarks;
                    instruction.RemarkDate = instructionViewModel.RemarkDate;
                    instruction.UserId = instructionViewModel.UserId;
                    instruction.PatientID = instructionViewModel.PatientID;
                    instruction.Status = instructionViewModel.Status;

                    _context.Update(instruction);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructionExists(instructionViewModel.InstructionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Repopulate dropdowns in case of validation error
            PopulateDropdowns(instructionViewModel);
            return View(instructionViewModel);
        }


        // GET: Instructions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Include both Users and Patient in the query to avoid null references in the view
            var instruction = await _context.NurseInstructions
                .Include(i => i.Users)
                .Include(i => i.Patient)
                .FirstOrDefaultAsync(m => m.InstructionId == id);

            if (instruction == null)
            {
                return NotFound();
            }

            return View(instruction);
        }

        // POST: Instructions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instruction = await _context.NurseInstructions.FindAsync(id);
            if (instruction == null)
            {
                return NotFound();
            }

            // Remove the instruction if found
            _context.NurseInstructions.Remove(instruction);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool InstructionExists(int id)
        {
            return _context.NurseInstructions.Any(e => e.InstructionId == id);
        }
    }
}

