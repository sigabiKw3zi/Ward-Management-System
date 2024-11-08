using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class Patient
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

        public List<string> MedicalHistory { get; set; } = new();
        public List<string> ChronicIllness { get; set; } = new();
        public List<string> Allergies { get; set; } = new();
        public List<string> CurrentMedication { get; set; } = new();

        public virtual ICollection<CurrentMedication> CurrentMedications { get; set; }
        public virtual ICollection<MedicalHistory> MedicalHistories { get; set; }
        public virtual ICollection<ChronicIllness> ChronicIllnesses { get; set; }

    }
}
