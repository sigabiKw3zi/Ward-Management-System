using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.ViewModels
{
    public class InstructionViewModel
    {
        public int InstructionId { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = null!;

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Created Date is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Remarks are required.")]
        public string Remarks { get; set; } = null!;

        [Required(ErrorMessage = "Please select a patient.")]
        public int PatientID { get; set; }

        // This is optional, so can be nullable
        public virtual Patient? Patient { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Remark Date is required.")]
        public DateTime RemarkDate { get; set; }

        [Required(ErrorMessage = "Please select a user.")]
        public string UserId { get; set; } = null!;

        // Navigational property to hold the list of patients and users
        public List<SelectListItem> Patients { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Users { get; set; } = new List<SelectListItem>();

        [Required(ErrorMessage = "Status is required.")]
        public string? Status { get; set; }
    }
}

