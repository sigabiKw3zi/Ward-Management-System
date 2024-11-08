using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.Controllers
{
    public interface IUserRepositories
    {
        Task<IEnumerable<IdentityUser>> GetUsersAsync();

        IEnumerable<SelectListItem> GetRoles();
    }
}
