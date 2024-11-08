
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class RoomManagementViewModel
    {
        public int BedId { get; set; }
        public int SelectedBedId { get; set; }
       
        public List<BedViewModel> Beds { get; set; }
        public int PatientID { get; set; }
        public List<SelectListItem> Patients { get; set; }
        public int TotalBeds { get; set; }
        public int AvailableBeds { get; set; }
        public string AllocatedTo { get; set; }
        [DataType(DataType.Date)]
        public DateTime AllocationDate { get; set; }
    }
}
