using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.ViewModels
{
    public class DischargeViewModel
    {
        public int DischargeId { get; set; }

        [Required]
        public DateOnly DischargeDate { get; set; }

        [Required]
        public string DischargeStatus { get; set; }


        public int PatientId { get; set; }

        [Required(ErrorMessage = "Please select a user.")]
        public string? UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // For displaying dropdowns of Patients and Users
        public SelectList Patients { get; set; } = new SelectList(new List<Patient>(), "PatientID", "FullName");
        public SelectList Users { get; set; } = new SelectList(new List<User>(), "Id", "FullName");
    }
}
