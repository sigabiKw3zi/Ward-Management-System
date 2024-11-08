namespace VirtualHealthProject.Models
{
    public class BedViewModel
    {
        public int BedID { get; set; }
        public string AllocatedTo { get; set; }
        public DateTime? AllocationDate { get; set; } // Use nullable if allocation date can be null
        public string AvailabilityStatus { get; set; }
        public bool IsOccupied { get; set; }
        public string RoomNumber { get; set; }
    }
}
