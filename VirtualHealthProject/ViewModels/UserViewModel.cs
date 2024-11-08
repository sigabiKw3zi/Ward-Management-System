using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.ViewModels
{
    public class UserViewModel
    {
       public List<User>? Users { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? SelectedRole { get; set; }

        public IEnumerable<SelectListItem>? Roles { get; set; }

    }
}
