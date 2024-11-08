using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.ViewModels
{
    public class LoginView
    {
        [Required(ErrorMessage ="Email is quired.")]
        [EmailAddress]
        public string Email {  get; set; }

        [Required(ErrorMessage = "Password is quired.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name="Remember me?")]
        public bool RememberMe { get; set; }
    }
}
