using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.Controllers
{
    public class ViewPatientFolderController : Controller
    {

        private readonly VirtualHealthDbContext _context;
        public ViewPatientFolderController(VirtualHealthDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var patients = _context.Patients.Select(p => new PatientViewModel
            {
                PatientID = p.PatientID,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                ContactNumber = p.ContactNumber,
                Email = p.Email

            }).ToList();

            return View(patients);
        }

        public async Task<IActionResult> ViewPatientFolder(int id)
        {
            var patientData = from p in _context.Patients
                              where p.PatientID == id
                              join m in _context.CurrentMedications on p.PatientID equals m.PatientID into medications
                              from med in medications.DefaultIfEmpty()
                              join h in _context.MedicalHistories on p.PatientID equals h.PatientID into histories
                              from hist in histories.DefaultIfEmpty()
                              join c in _context.ChronicIllnesses on p.PatientID equals c.PatientID into illnesses
                              from ill in illnesses.DefaultIfEmpty()
                              select new
                              {
                                  Patient = p,
                                  MedicationDescription = med.Description,
                                  MedicalHistoryDescription = hist.Description,
                                  ChronicIllnessDescription = ill.Description
                              };

            var patientList = await patientData.ToListAsync();

            // Check if patient data was found
            if (!patientList.Any())
            {
                return NotFound(); // Return a 404 if no patient is found
            }

            // Create the view model
            var model = new PatientViewModel
            {
                FirstName = patientList.First().Patient.FirstName,
                LastName = patientList.First().Patient.LastName,
                DateOfBirth = patientList.First().Patient.DateOfBirth,
                Gender = patientList.First().Patient.Gender,
                ContactNumber = patientList.First().Patient.ContactNumber,
                Email = patientList.First().Patient.Email,
                Address = patientList.First().Patient.Address,
                PostalCode = patientList.First().Patient.PostalCode,
                PrimaryConcern = patientList.First().Patient.PrimaryConcern,
                SelectedCurrentMedication = patientList.Select(x => x.MedicationDescription).Distinct().ToList(),
                SelectedMedicalHistory = patientList.Select(x => x.MedicalHistoryDescription).Distinct().ToList(),
                SelectedChronicIllness = patientList.Select(x => x.ChronicIllnessDescription).Distinct().ToList(),
            };

            return View(model); // Return the view with the patient data
        }
    }
}
