using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class PatientViewModel
    {
        [Key]
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PrimaryConcern { get; set; }
        public List<string> SelectedCurrentMedication { get; set; } = new List<string>();
        public List<string> SelectedMedicalHistory { get; set; } = new List<string>();
        public List<string> SelectedChronicIllness { get; set; } = new List<string>();
        public List<string> SelectedAllergies { get; set; } = new();


        public IEnumerable<SelectListItem> MedicalHistoryOptions { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> ChronicIllnessOptions { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> CurrentMedicationOptions { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> AllergiesOptions { get; set; } = new List<SelectListItem>();
    }
}


