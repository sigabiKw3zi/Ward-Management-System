using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VirtualHealthProject.Models
{
    public class Vitals
    {
          // Use the [Key] attribute to mark the primary key
        [Key][Required]
        public int VitalsId { get; set; }  // Define a primary key
        
        public DateTime AdmissionDate { get; set; }
        //public string CurrentMed { get; set; }
        public string? Temperature { get; set; }
        public string? PulseRate { get; set; }
        public string? BloodPressure { get; set; }
        public string? PainLevel { get; set; }

        public string? ScheduleMedication { get; set; }
        [ValidateNever]
        public string? scheduleIVMedications { get; set; }
        [ValidateNever]
        public string? scheduleVMedications { get; set; }
    }
}
