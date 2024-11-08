using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class NurseInstruction
    {
        [Key]
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

        public virtual Patient? Patient { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Remark Date is required.")]
        public DateTime RemarkDate { get; set; }

        // Foreign key for User
        [Required(ErrorMessage = "Please select a user.")]
        public string UserId { get; set; } = null!;

        public virtual User? Users { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string? Status { get; set; }
    }
}

