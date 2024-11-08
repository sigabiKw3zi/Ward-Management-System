using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace VirtualHealthProject.Models
{
    public class Prescription
    {
        [Key]  // Add this attribute to designate the primary key
        public int PrescriptionId { get; set; }  // This property acts as the primary key

        public int PatientId { get; set; } // Auto-increment if necessary
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateRecorded { get; set; }
        public string Rx { get; set; } // Medication prescribed
        public string Sig { get; set; } // Dosage instructions
        public string Dispense { get; set; } // Number of dispensed items
        public string Rf { get; set; } // Refill count
        public DateTime ExpDate { get; set; }
        public string Notes { get; set; }
    }

}
