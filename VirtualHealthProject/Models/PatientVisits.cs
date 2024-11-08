using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualHealthProject.Models
{
        public class PatientVisits
        {
            [Key]
            public int VisitsId { get; set; }

            [Display(Name = "Visit Date")]
            [DataType(DataType.Date)]
            public DateTime VisitDateTime { get; set; }

            [Required]
            public string Note { get; set; } = null!;

            [Display(Name = "Patient")]
            public int PatientID { get; set; }

            [Display(Name = "User")]
            public string? UserId { get; set; }  
           
            public virtual Patient Patient { get; set; } = null!;  
            public virtual User User { get; set; } = null!;  

           
            [NotMapped]
            public string PatientFullName => $"{Patient?.FirstName} {Patient?.LastName}";

            [NotMapped]
            public string UserFullName => $"{User?.FirstName} {User?.LastName}";
        }
    

}


