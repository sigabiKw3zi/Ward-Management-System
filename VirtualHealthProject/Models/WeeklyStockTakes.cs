using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class WeeklyStockTakes
    {
        [Key]
        public int StockTakeID { get; set; } // Primary Key

        [Required(ErrorMessage = "Manager name is required")]
        [StringLength(100, ErrorMessage = "Manager name cannot be longer than 100 characters")]
        public string ManagerName { get; set; } // Name of the stock manager

        [Required(ErrorMessage = "Request date and time are required.")]
        [Display(Name = "Date and Time")]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Consumable name is required")]
        [StringLength(100, ErrorMessage = "Consumable name cannot be longer than 100 characters")]
        public string ConsumableName { get; set; } // Name of the consumable item

        [Required(ErrorMessage = "Available Stock is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Available stock must be a positive number")]
        public int AvailableStock { get; set; } // Quantity of consumables currently available

        [Required(ErrorMessage = "Stock Needed is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Stock Needed must be at least 1")]
        public int StockNeeded { get; set; } // Required stock level for the consumable

        [StringLength(200, ErrorMessage = "Comments cannot be longer than 500 characters")]
        public string Comment { get; set; } // Additional comments from the stock manager
    }
}
