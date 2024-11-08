using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class DoctorVisits
    {
        // The actual DoctorVisit entity to hold the form data
        [Key]
        public int VisitsId { get; set; }

        [Display(Name = "Visit Date")]
        [DataType(DataType.Date)]
        public DateTime VisitDateTime { get; set; }

        public string Note { get; set; } = null!;

        [Display(Name = "Patient")]
        public int PatientID { get; set; }

        [Display(Name = "User")]
        public string? UserId { get; set; }

        public string PatientFullName { get; set; } = null!;
        public string UserFullName { get; set; } = null!;

        // For displaying dropdowns of Patients and Users
       public virtual Patient Patients { get; set; }

        public virtual User Users { get; set; }  
    }
}


