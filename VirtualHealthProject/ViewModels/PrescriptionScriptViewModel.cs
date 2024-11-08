using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.ViewModels
{
    public class PrescriptionScriptViewModel
    {
        public int PrescriptionID { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int PatientID { get; set; }

        [Required]
        [Display(Name ="Doctor")]
        public string? UserId { get; set; }

        [Required]
        [Display(Name = "Medication")]
        public string? Medication { get; set; }

        [Required]
        [Display(Name = "Dosage")]
        public string? Dosage { get; set; }

        [Required]
        [Display(Name = "Date Prescribed")]
        [DataType(DataType.Date)]
        public DateTime DateWritten { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string? Status { get; set; }

        [Display(Name = "Date Forwarded to Pharmacy")]
        [DataType(DataType.Date)]
        public DateTime? DateForwardedToPharmacy { get; set; }

        [Display(Name = "Date Delivered To Ward")]
        [DataType(DataType.Date)]
        public DateTime? DateDeliveredToWard { get; set; }

        public List<SelectListItem>? PatientList { get; set; }
        public List<SelectListItem>? DoctorList { get; set; }

    }
}
