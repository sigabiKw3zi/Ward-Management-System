using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.ViewModels
{
    public class RegisterView
    {
        [Required(ErrorMessage="Name is required.")]

        public string Name {  get; set; }

        [Required(ErrorMessage = "Email is quired.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is quired.")]
        [StringLength(40,MinimumLength =8,ErrorMessage ="The {0} must be atleast {2} and at max {1} character length")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword",ErrorMessage ="Password does not match")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is quired.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm  Password")]
        public string ConfirmPassword { get; set; }
    }
}
