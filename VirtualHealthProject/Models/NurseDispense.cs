using System;
using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class NurseDispense
    {
        [Key]
        public int DispenceId { get; set; }

        [Required(ErrorMessage = "Scheduled Medication is required.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "The name field can only contain letters.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        [Display(Name = "Scheduled Medication")]
        public string ScheduledMedication { get; set; }

        [Required(ErrorMessage = "Patient Name is required.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "The name field can only contain letters.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        [Display(Name = "Patient Name")]
        public string? PatientName { get; set; }

        [Required(ErrorMessage = "Collection date and time are required.")]
        [Display(Name = "Date Prescribed")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePrescribed { get; set; }

        [Required(ErrorMessage = "Medicine name is required.")]
        [StringLength(100, ErrorMessage = "Medicine name should not exceed 100 characters.")]
        [Display(Name = "Medicine Prescribed (Rx)")]
        public string MedicineName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        [Display(Name = "Quantity (Dispense)")]
        public int Quantity { get; set; }

        [StringLength(200, ErrorMessage = "Notes should not exceed 200 characters.")]
        [Display(Name = "Dosage")]
        public string Dosage { get; set; }
    }
}
