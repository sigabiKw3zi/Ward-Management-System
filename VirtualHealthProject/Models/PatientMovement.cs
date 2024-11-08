using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class PatientMovement
    {
        [Key]
      public int PatientMovementID { get; set; }
      public int PatientID { get; set; }  
      public string Movement { get; set; }
      public DateTime MovementTime { get; set; }
     public DateTime? ReturnTime { get; set; }

      public virtual Patient Patient { get; set; } 
    }
}

