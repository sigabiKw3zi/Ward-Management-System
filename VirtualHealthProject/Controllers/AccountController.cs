using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirtualHealthProject.ViewModels;
using VirtualHealthProject.Models;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VirtualHealthProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountController(SignInManager<User>signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginView model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to sign in the user
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    // Find the user by email
                    var user = await userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        // Get the user's roles
                        var roles = await userManager.GetRolesAsync(user);

                        // Redirect based on role
                        if (roles.Contains("Nurse"))
                        {
                            return RedirectToAction("PatientCare", "Home");
                        }
                        else if (roles.Contains("Administrator"))
                        {
                            return RedirectToAction("Administration", "Home");
                        }
                        // Add more roles as needed
                        //else if (roles.Contains("WardAdmin"))
                        //{
                        //    return RedirectToAction("PatientManagement", "Home");
                        //}

                        else if (roles.Contains("Doctor"))
                        {
                            return RedirectToAction("DoctorPatient", "Home");
                        }

                        else if (roles.Contains("ScriptManager"))
                        {
                            return RedirectToAction("Script", "Home");
                        }
                        else if (roles.Contains("Pharmacist"))
                        {
                            return RedirectToAction("PharmacyDash", "Home");
                        }

                        else if (roles.Contains("StockManager"))
                        {
                            return RedirectToAction("ConScript", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Dashboard", "PatientFolder"); // Default redirection
                        }
                    }
                }
                ModelState.AddModelError("", "Email or password is incorrect.");
                return View(model);
            }
            return View(model);
        }


        //[HttpPost]
        //public async Task<IActionResult> Login(LoginView  model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);

        //        if(result.Succeeded)
        //        {
        //            //You will get user infor and role
        //            //if (result.Role == "Doctor")
        //            //{
        //            //    return RedirectToAction("Index", "Employees");
        //            //}
        //            return RedirectToAction("Index", "Employees");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Email or password is incorrect.");
        //            return View(model);
        //        }


        //    }
        //    return View(model);
        //}



        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(RegisterView model)
        {
            if (ModelState.IsValid)
            {
                User users = new User
                {

                    FirstName = model.Email,
                    LastName = model.Email,
                    Email = model.Email,
                    UserName = model.Email,
                };

                var result = await userManager.CreateAsync(users, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
                
            }
                    return View(model);
        }            
        public IActionResult VerifyEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailView model)
        {
            if (ModelState.IsValid)
            {
                var user =await userManager.FindByNameAsync(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError("", "Something is wrong!");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("ChangePassword","Account",new {username=user.UserName});
                }
            }
            return View(model);
        }
        public IActionResult ChangePassword(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("VerifyEmail", "Account");
            }
            return View(new ChangePasswordView { Email=username});
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordView model)
        {
            if (ModelState.IsValid)
            {
               var user = await userManager.FindByEmailAsync(model.Email);
               if(user != null)
                {
                    var result = await userManager.RemovePasswordAsync(user);
                    if(result.Succeeded)
                    {
                        result=await userManager.AddPasswordAsync(user,model.NewPassword);
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("","Email not fount");
                    return View(model);
                }
            }
            else
            {

                ModelState.AddModelError("", "Something went wrong.try again.");
                return View(model);
            }
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        //Access Denied View
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
