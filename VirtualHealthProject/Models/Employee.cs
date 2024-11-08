using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class Employee : UserActivity
    {

        [Key]
        public int EmployeeID { get; set; }

        public string EmpNo { get; set; }   

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(100, ErrorMessage = "Surname can't be longer than 100 characters.")]
        public string Surname { get; set; } = "";

        
        public string FullName=> $"{Name} {Surname}";

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailAddress { get; set; } = "";

        [Required(ErrorMessage = "Mobile number is required.")]
        [Phone(ErrorMessage = "Invalid Mobile number.")]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}", ErrorMessage = "Mobile must be in the format XXX-XXX-XXXX.")]
        public string Mobile { get; set; } = "";

        [Required(ErrorMessage = "Join date is required.")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; } = "";

        public string Address { get; set; } = "";
    }
}
