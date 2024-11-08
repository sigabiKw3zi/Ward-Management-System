using Microsoft.AspNetCore.Identity;

namespace VirtualHealthProject.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
