using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class AdmissionViewModel
    {
        [Key]
        public int AdmissionId { get; set; }

        [Required]
        public int PatientID { get; set; }
        [Required]
        public int SelectedPatientID { get; set; }
        [Required]
        public string? PatientName { get; set; }

        //public string? DoctorID { get; set; }

        //public string? DoctorAssigned { get; set; }

        public List<SelectListItem>? Patients { get; set; }
        public List<SelectListItem> PatientOptions { get; set; }

        //public List<SelectListItem>? Doctors{ get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; }


        public string Status { get; set; } 
    }
}
