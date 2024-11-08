using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualHealthProject.Models
{
    public class Bed
    {
        [Key]
        public int BedID { get; set; }
        public int RoomID { get; set; }
        public string AllocatedTo { get; set; }
        public string RoomNumber { get; set; }
        public bool IsOccupied { get; set; }
        public DateTime? AllocationDate { get; set; }

        public virtual Room Room { get; set; }
        public virtual BedAllocation BedAllocation { get; set; }

        public class IsOccupiedConverter : ValueConverter<int, bool>
        {
            public IsOccupiedConverter() : base(
                v => v == 1, // Convert int to bool
                v => v ? 1 : 0) // Convert bool to int
            { }

        }
    }
}
