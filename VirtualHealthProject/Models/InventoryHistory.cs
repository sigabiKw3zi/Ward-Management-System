using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class InventoryHistory
    {
        [Key]
        public int InventoryHistoryId { get; set; }  // Primary key

        [Required]
        [ForeignKey("Consumable")]
        [Display(Name = "Consumable")]
        public int ConsumableId { get; set; }  // Foreign key to the Consumable entity

        //public Consumable Consumable { get; set; }  // Navigation property to the Consumable entity

        [Required]
        [Display(Name = "Movement Type")]
        public string MovementType { get; set; }  // Type of movement: Order, Delivery, Usage

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }  // Quantity involved in the movement

        [Required]
        [Display(Name = "Date of Movement")]
        public DateTime MovementDate { get; set; }  // Date when the movement occurred

        [Display(Name = "Notes")]
        public string Notes { get; set; }  // Additional notes or comments (e.g., reason for usage)
    }
}
