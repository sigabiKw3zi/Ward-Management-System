using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.ViewModels
{
    public class VerifyEmailView
    {
        [Required(ErrorMessage = "Email is quired.")]
        [EmailAddress]
        public string Email { get; set; }
}   }
