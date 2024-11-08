using System.ComponentModel.DataAnnotations;


namespace VirtualHealthProject.Models
{
    public class ReferralLetter
    {
        [Key]
        public int ReferralID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string PrimaryConcern { get; set; }
        public string CurrentMedications { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }

      
      
    }
}
