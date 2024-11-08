using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class Discharge
    {
        [Key]
        public int DischargeId { get; set; }

        [Required]
        public DateOnly DischargeDate { get; set; }

        [Required]
        public string DischargeStatus { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        public string? UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual Patient Patient { get; set; }

        public virtual User User { get; set; }

        public Discharge()
        {
            DischargeStatus = "Pending";
          
        }
       
    }
}
