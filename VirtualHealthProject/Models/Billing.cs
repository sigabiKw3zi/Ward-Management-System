using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class Billing
    {
        [Key]
        public int BillId { get; set; }

        [Required(ErrorMessage = "Scheduled Medication is required.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Scheduled Medication can only contain letters.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Scheduled Medication must be between 2 and 50 characters.")]
        [Display(Name = "Scheduled Medication")]
        public string ScheduledMedication { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "First Name can only contain letters.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Last Name can only contain letters.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Admission Date is required.")]
        [Display(Name = "Admission Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AdmissionDate { get; set; }

        [Required(ErrorMessage = "Discharge Date is required.")]
        [Display(Name = "Discharge Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DischargeDate { get; set; }

        [Required(ErrorMessage = "Bed Charge is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Bed Charge must be a positive number.")]
        [Display(Name = "Bed Charge")]
        public decimal BedCharge { get; set; }

        [Required(ErrorMessage = "Medication Charge is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Medication Charge must be a positive number.")]
        [Display(Name = "Medication Charge")]
        public decimal MedicationCharge { get; set; }

        [Required(ErrorMessage = "Service Charge is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Service Charge must be a positive number.")]
        [Display(Name = "Service Charge")]
        public decimal ServiceCharge { get; set; }

        [Required(ErrorMessage = "Total Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Total Amount must be a positive number.")]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Amount Paid is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount Paid must be a positive number.")]
        [Display(Name = "Amount Paid")]
        public decimal AmountPaid { get; set; }

        [Required(ErrorMessage = "Payment Status is required.")]
        [Display(Name = "Payment Status")]
        public string PaymentStatus { get; set; } // "Paid", "Pending", "Partially Paid"

        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PaymentDate { get; set; }
    }


}
