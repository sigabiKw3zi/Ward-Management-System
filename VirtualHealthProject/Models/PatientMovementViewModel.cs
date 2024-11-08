using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VirtualHealthProject.Models
{
    public class PatientMovementViewModel
    {
            public int PatientMovementID { get; set; }

            [Required]
            public int PatientID { get; set; }
             public int SelectedPatientID { get; set; }

            [Required]
            [StringLength(100)]
            public string Movement { get; set; }

            [Required]
            [Display(Name = "Movement Time")]
            [DataType(DataType.DateTime)]
            public DateTime MovementTime { get; set; }

            [Display(Name = "Return Time")]
            [DataType(DataType.DateTime)]
            public DateTime? ReturnTime { get; set; }
            public List<SelectListItem> PatientOptions { get; set; }

    }
}
