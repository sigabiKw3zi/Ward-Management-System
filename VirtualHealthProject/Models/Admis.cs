using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class Admis
    {

        [Key]
        public int AdmissionId { get; set; }

        public int PatientID { get; set; }

        public string PatientName { get; set; }

        public String? UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Admitted";

        public virtual Patient? Patient { get; set; } // Link to the patient
        public virtual User? User { get; set; }
    }
}
