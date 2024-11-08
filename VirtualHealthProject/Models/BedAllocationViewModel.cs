using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class BedAllocationViewModel
    {
        [Key]
        public int AllocationID { get; set; }
        public int BedID { get; set; }
        public int RoomID { get; set; }
        public bool IsOccupied { get; set; }
        public int SelectedBedId { get; set; }
        public int SelectedAllocationID { get; set; }
        public string RoomNumber { get; set; } 
        public List<BedViewModel> Beds { get; set; }
        public int PatientID { get; set; }
        public List<SelectListItem> Patients { get; set; }
        public int TotalBeds { get; set; }
        public int AvailableBeds { get; set; }
        public string AllocatedTo { get; set; }
        [DataType(DataType.Date)]
        public DateTime AllocationDate { get; set; }
        public List<SelectListItem> BedAllocation { get; set; }
        public List<SelectListItem> AllocationOptions { get; set; }
        public int SelectedBedID { get; set; } // To hold the selected BedID
        public List<SelectListItem> BedOptions { get; set; } // For BedID dropdown
        public int SelectedPatientID { get; set; } // To hold the selected Patient ID
        public List<SelectListItem> PatientOptions { get; set; } // For Patient dropdown
        public List<SelectListItem> RoomOptions { get; set; }
    }
}
