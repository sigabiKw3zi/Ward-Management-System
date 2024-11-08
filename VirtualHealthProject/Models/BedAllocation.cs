using System.ComponentModel.DataAnnotations;


namespace VirtualHealthProject.Models
{
    public class BedAllocation
    {
        [Key]
        public int AllocationID { get; set; }
        public int BedID { get; set; }
        public string RoomNumber { get; set; }
        public int PatientID { get; set; }
        public DateTime AllocationDate { get; set; }

        // Navigation properties
        public virtual Bed Bed { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
