using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace VirtualHealthProject.Models
{
    public class PrescriptionScript
    {
        [Key]
        public int PrescriptionID { get; set; } // Primary key

        [Required]
        public int PatientID { get; set; } // Foreign key to the Patient model

        [Required]
        public string? UserId { get; set; } // Foreign key to the Doctor model

        [Required]
        public string? Medication { get; set; } // Medication prescribed

        public string? Dosage { get; set; } // Dosage information

        [Required]
        public DateTime DateWritten { get; set; } // Date the prescription was written

        public string? Status { get; set; } // e.g. Pending, Forwarded, Delivered

        public DateTime? DateForwardedToPharmacy { get; set; } // Date the prescription was forwarded to pharmacy
        public DateTime? DateDeliveredToWard { get; set; } // Date the prescription was delivered to the ward

        public virtual Patient? Patient { get; set; }
        public virtual User? Doctor { get; set; }


    }
}
