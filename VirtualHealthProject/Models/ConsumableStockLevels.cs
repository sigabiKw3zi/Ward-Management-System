using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class ConsumableStockLevels
    {
        [Key]
        public int ConsumableId { get; set; }

        [Required]
        [Display(Name = "Consumable Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Stock Level")]
        public int StockLevel { get; set; }

        [Required]
        [Display(Name = "Reorder Stock")]
        public int ReorderLevel { get; set; }

       
        [Required]
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

      
        public bool IsLowStock()
        {
            return StockLevel <= ReorderLevel;
        }

   
        public bool IsExpired()
        {
            return ExpirationDate < DateTime.Now;
        }
    }
}

