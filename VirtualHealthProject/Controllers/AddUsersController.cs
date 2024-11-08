using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualHealthProject.ViewModels;
using VirtualHealthProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.Controllers
{
    public class AddUsersController : Controller
    {
        private readonly IUserRepositories userRepositories;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public AddUsersController(IUserRepositories userRepositories, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userRepositories = userRepositories;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var userViewModel = new UserViewModel();

            //roles
            var roles = userRepositories.GetRoles().Select(r => new SelectListItem
            {
                Value = r.Value,
                Text = r.Text
            }).ToList();

            userViewModel.Roles = roles;

            var users = await userRepositories.GetUsersAsync();

            //var userViewModel = new UserViewModel();

            userViewModel.Users = new List<User>();
            foreach (var user in users)
            {
                userViewModel.Users.Add(new Models.User
                {
                    UserName = user.UserName,
                    Email = user.Email,
                });
            }
            return View(userViewModel);
        }

       
       
        [HttpPost]
        public async Task<IActionResult> List(UserViewModel userViewModel)
        {

            // Create the user
            var identityUser = new User
            {
                UserName = userViewModel.UserName,
                Email = userViewModel.Email,
            };

            var identityResult = await userManager.CreateAsync(identityUser, userViewModel.Password);

            if (identityResult.Succeeded)
            {
                // Assign the selected role to the user
                if (!string.IsNullOrEmpty(userViewModel.SelectedRole))
                {
                    // Check if the role exists and assign the role to the user
                    if (await roleManager.RoleExistsAsync(userViewModel.SelectedRole))
                    {
                        await userManager.AddToRoleAsync(identityUser, userViewModel.SelectedRole);
                    }
                }

                // Redirect to List on success
                return RedirectToAction("List", "AddUsers");
            }
            else
            {
                // Handle failure (e.g., invalid password or user creation failure)
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            // Return the view with the same model (e.g., to display validation errors)
            return View(userViewModel);
        }

    }
}

