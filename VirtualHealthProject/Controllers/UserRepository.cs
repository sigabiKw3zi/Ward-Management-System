using VirtualHealthProject.Models;
using Microsoft.AspNetCore.Identity;
using VirtualHealthProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualHealthProject.ViewModels;

namespace VirtualHealthProject.Controllers
{
    public class UserRepository : IUserRepositories
    {
        private readonly VirtualHealthDbContext virtualHealthDbContext;

        public UserRepository(VirtualHealthDbContext virtualHealthDbContext)
        {
            this.virtualHealthDbContext = virtualHealthDbContext;
        }

        public IEnumerable<SelectListItem> GetRoles()
        {
            return virtualHealthDbContext.Roles.Select(r => new SelectListItem
            {
                Value = r.Id,
                Text = r.Name
            }).ToList();

        }

        public async Task<IEnumerable<IdentityUser>> GetUsersAsync()
        {
            var users = await virtualHealthDbContext.Users.ToListAsync();

            var adminUser = await virtualHealthDbContext.Users.FirstOrDefaultAsync(x => x.Email == "admin@virtualhealthbridge.com");

            if (adminUser is not null)
            {
                users.Remove(adminUser);
            }

            return users;
        }
    }
}
