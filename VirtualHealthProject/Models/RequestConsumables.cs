using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class RequestConsumables
    {
       
            [Key]
            public int Id { get; set; } // Unique identifier for the request
            public string ConsumableName { get; set; } // Foreign key for the consumable item
            public string Notes { get; set; } // Foreign key for the requestor (staff)
            public int Quantity { get; set; } // The number of items requested
            public string Status { get; set; } // Status of the request (e.g., Pending, Approved)
            public DateTime RequestDate { get; set; } // The date when the request was made
        

    }
}
