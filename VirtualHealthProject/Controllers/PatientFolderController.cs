using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualHealthProject.Data;
using VirtualHealthProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace VirtualHealthProject.Controllers
{
    //[Authorize(Roles = "WardAdmin")]
    public class PatientFolderController : Controller
    {
        private readonly VirtualHealthDbContext _context;
        public PatientFolderController(VirtualHealthDbContext context)
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
        public async Task<IActionResult> Dashboard()
        {

            return View();
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


        public IActionResult Create()
        {
            var model = new PatientViewModel()
            {
               MedicalHistoryOptions = GetMedicalHistoryOptions(),
               CurrentMedicationOptions = GetCurrentMedicationOptions(),
               ChronicIllnessOptions = GetChronicIllnessOptions(),
               AllergiesOptions = GetAllergyOptions()
            };

            return View(model);
        }
        private IEnumerable<SelectListItem> GetMedicalHistoryOptions()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "None", Text = "None" },
        new SelectListItem { Value = "Hypertension", Text = "Hypertension" },
        new SelectListItem { Value = "DiabetesMellitus", Text = "Diabetes Mellitus" },
        new SelectListItem { Value = "Asthma", Text = "Asthma" },
        new SelectListItem { Value = "HeartDisease", Text = "Heart Disease" },
        new SelectListItem { Value = "Stroke", Text = "Stroke" },
        new SelectListItem { Value = "KidneyDisease", Text = "Kidney Disease" },
        new SelectListItem { Value = "LiverDisease", Text = "Liver Disease" },
        new SelectListItem { Value = "Cancer", Text = "Cancer" },
        new SelectListItem { Value = "MentalHealthDisorders", Text = "Mental Health Disorders (e.g., Depression, Anxiety)" },
        new SelectListItem { Value = "AutoimmuneDisorders", Text = "Autoimmune Disorders (e.g., Lupus, Rheumatoid Arthritis)" },
        new SelectListItem { Value = "NeurologicalDisorders", Text = "Neurological Disorders (e.g., Epilepsy, Multiple Sclerosis)" },
        new SelectListItem { Value = "PreviousSurgeries", Text = "Previous Surgeries (e.g., Appendectomy, Gallbladder Removal)" },
        new SelectListItem { Value = "FamilyHistoryHeartDisease", Text = "Family History of Heart Disease" },
        new SelectListItem { Value = "FamilyHistoryCancer", Text = "Family History of Cancer" }
    };
        }

        private IEnumerable<SelectListItem> GetChronicIllnessOptions()
        {
            return new List<SelectListItem>
           {
               new SelectListItem { Value = "None", Text = "None" },
        new SelectListItem { Value = "COPD", Text = "Chronic Obstructive Pulmonary Disease (COPD)" },
        new SelectListItem { Value = "ChronicKidneyDisease", Text = "Chronic Kidney Disease" },
        new SelectListItem { Value = "DiabetesType1", Text = "Diabetes Type 1" },
        new SelectListItem { Value = "DiabetesType2", Text = "Diabetes Type 2" },
        new SelectListItem { Value = "Fibromyalgia", Text = "Fibromyalgia" },
        new SelectListItem { Value = "ChronicFatigueSyndrome", Text = "Chronic Fatigue Syndrome" },
        new SelectListItem { Value = "IBD", Text = "Inflammatory Bowel Disease (e.g., Crohn's Disease, Ulcerative Colitis)" },
        new SelectListItem { Value = "Osteoporosis", Text = "Osteoporosis" },
        new SelectListItem { Value = "CardiovascularDisease", Text = "Cardiovascular Disease" },
        new SelectListItem { Value = "ChronicPainSyndromes", Text = "Chronic Pain Syndromes" },
        new SelectListItem { Value = "ThyroidDisorders", Text = "Thyroid Disorders (e.g., Hypothyroidism, Hyperthyroidism)" },
        new SelectListItem { Value = "SleepApnea", Text = "Sleep Apnea" }
    };
        }

        private IEnumerable<SelectListItem> GetCurrentMedicationOptions()
        {
            return new List<SelectListItem>
    {
             new SelectListItem { Value = "None", Text = "None" },
        new SelectListItem { Value = "Aspirin", Text = "Aspirin" },
        new SelectListItem { Value = "Ibuprofen", Text = "Ibuprofen" },
        new SelectListItem { Value = "Metformin", Text = "Metformin" },
        new SelectListItem { Value = "Lisinopril", Text = "Lisinopril" },
        new SelectListItem { Value = "Atorvastatin", Text = "Atorvastatin" },
        new SelectListItem { Value = "Levothyroxine", Text = "Levothyroxine" },
        new SelectListItem { Value = "Omeprazole", Text = "Omeprazole" },
        new SelectListItem { Value = "Losartan", Text = "Losartan" },
        new SelectListItem { Value = "Albuterol", Text = "Albuterol" },
        new SelectListItem { Value = "Sertraline", Text = "Sertraline" },
         new SelectListItem { Value = "Hydrochlorothiazide", Text = "Hydrochlorothiazide" },
        new SelectListItem { Value = "Gabapentin", Text = "Gabapentin" },
        new SelectListItem { Value = "Citalopram", Text = "Citalopram" },
        new SelectListItem { Value = "Simvastatin", Text = "Simvastatin" },
        new SelectListItem { Value = "Furosemide", Text = "Furosemide" },
        new SelectListItem { Value = "Zoloft", Text = "Zoloft" },
        new SelectListItem { Value = "Fluticasone", Text = "Fluticasone" },
        new SelectListItem { Value = "Clonazepam", Text = "Clonazepam" },
        new SelectListItem { Value = "Montelukast", Text = "Montelukast" },
        new SelectListItem { Value = "Duloxetine", Text = "Duloxetine" },
        new SelectListItem { Value = "Trazodone", Text = "Trazodone" },
        new SelectListItem { Value = "Bupropion", Text = "Bupropion" },
        new SelectListItem { Value = "Warfarin", Text = "Warfarin" },
        new SelectListItem { Value = "Tramadol", Text = "Tramadol" },
        new SelectListItem { Value = "Amlodipine", Text = "Amlodipine" },
        new SelectListItem { Value = "Epinephrine", Text = "Epinephrine" },
        new SelectListItem { Value = "Ciprofloxacin", Text = "Ciprofloxacin" },
        new SelectListItem { Value = "Amoxicillin", Text = "Amoxicillin" },
        new SelectListItem { Value = "Azithromycin", Text = "Azithromycin" },
        new SelectListItem { Value = "Metoprolol", Text = "Metoprolol" },
        new SelectListItem { Value = "Pantoprazole", Text = "Pantoprazole" },
        new SelectListItem { Value = "Naproxen", Text = "Naproxen" },
        new SelectListItem { Value = "Cephalexin", Text = "Cephalexin" },
    };
        }

        private IEnumerable<SelectListItem> GetAllergyOptions()
        {
            return new List<SelectListItem>
            {
                  new SelectListItem { Value = "None", Text = "None" },
         new SelectListItem { Value = "Pollen", Text = "Pollen (Hay Fever)" },
        new SelectListItem { Value = "DustMites", Text = "Dust Mites" },
        new SelectListItem { Value = "AnimalDander", Text = "Animal Dander (e.g., Cats, Dogs)" },
        new SelectListItem { Value = "Foods", Text = "Foods (e.g., Peanuts, Tree Nuts, Shellfish, Milk, Eggs, Wheat, Soy)" },
        new SelectListItem { Value = "Medications", Text = "Medications (e.g., Penicillin, Aspirin)" },
        new SelectListItem { Value = "InsectStings", Text = "Insect Stings (e.g., Bees, Wasps)" },
        new SelectListItem { Value = "Latex", Text = "Latex" },
        new SelectListItem { Value = "Mold", Text = "Mold" },
        new SelectListItem { Value = "Fragrances", Text = "Fragrances/Chemicals" },
        new SelectListItem { Value = "EnvironmentalAllergens", Text = "Other Environmental Allergens" }
    };
        }

        [HttpPost]
        public IActionResult Create(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var patient = new Patient
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    ContactNumber = model.ContactNumber,
                    Email = model.Email,
                    Address = model.Address,
                    PostalCode = model.PostalCode,
                    PrimaryConcern = model.PrimaryConcern
                };

                _context.Patients.Add(patient);
               _context.SaveChanges();

                if (model.SelectedMedicalHistory != null && model.SelectedMedicalHistory.Count > 0)
                {
                    foreach (var history in model.SelectedMedicalHistory)
                    {
                        _context.MedicalHistories.Add(new MedicalHistory
                        {
                            PatientID = patient.PatientID,
                            Description = history
                        });
                    }
                    _context.SaveChanges(); // Save all related medical histories
                }

                if (model.SelectedCurrentMedication != null && model.SelectedCurrentMedication.Count > 0)
                {
                    foreach (var medication in model.SelectedCurrentMedication)
                    {
                        _context.CurrentMedications.Add(new CurrentMedication
                        {
                            PatientID = patient.PatientID,
                            Description = medication 
                        });
                    }
                    _context.SaveChanges(); // Save all related current medications
                }

                if (model.SelectedChronicIllness != null && model.SelectedChronicIllness.Count > 0)
                {
                    foreach (var illness in model.SelectedChronicIllness)
                    {
                        _context.ChronicIllnesses.Add(new ChronicIllness
                        {
                            PatientID = patient.PatientID,
                            Description = illness 
                        });
                    }
                    _context.SaveChanges(); // Save all related chronic illnesses
                }


                if (model.SelectedAllergies != null && model.SelectedAllergies.Count > 0)
                {
                    foreach (var allergy in model.SelectedAllergies)
                    {
                        _context.Allergies.Add(new Allergy
                        {
                            PatientID = patient.PatientID,
                            Description = allergy, 
                           
                        });
                    }
                    _context.SaveChanges(); // Save all related allergies
                }
                return RedirectToAction("Index");
            }

            // If we got this far, something failed, redisplay form
            model.MedicalHistoryOptions = GetMedicalHistoryOptions();
            model.CurrentMedicationOptions = GetCurrentMedicationOptions();
            model.ChronicIllnessOptions = GetChronicIllnessOptions();
            model.AllergiesOptions = GetAllergyOptions();
            return View(model);
        }
        
    }
}

