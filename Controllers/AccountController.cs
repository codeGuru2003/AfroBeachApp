using AfroBeachApp.Models;
using AfroBeachApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AfroBeachApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.EmailAddress);

                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    await _signInManager.SignInAsync(user, model.RememberMe);
                    //var loginInfo = new LoginLog
                    //{
                    //    UserName = model.Username,
                    //    IPAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                    //    DateTimeLogOn = DateTime.Now
                    //};

                    //_context.LoginLogs.Add(loginInfo);
                    //await _context.SaveChangesAsync();

                    // Redirect the user based on their role
                    if (await _userManager.IsInRoleAsync(user, "Superadmin"))
                    {
                        return RedirectToAction(actionName:"Default", controllerName:"Admin");
                    }
                    else if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("Default", "Admin");
                    }
                    else if (await _userManager.IsInRoleAsync(user, "Manager"))
                    {
                        return RedirectToAction("Default", "Admin");
                    }
                    else if(await _userManager.IsInRoleAsync(user,"Customer"))
                    {
                        return RedirectToAction("Shop", "Home");
                    }
                }

                TempData["Message"] = "Invalid Login Attempt";
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        [Authorize(Roles ="Superadmin, Admin")]
        [HttpGet]
        public IActionResult Users()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        [Authorize(Roles = "Superadmin, Admin")]
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(ApplicationUser applicationUser, IFormFile file, String roleName)
        {
            if (applicationUser != null)
            {
                if (file.Length > 200 * 1024)
                {
                    TempData["Message"] = "Picture size exceeds 200 kilobytes";
                }
                else
                {
                    using (MemoryStream memory = new MemoryStream())
                    {
                        await file.CopyToAsync(memory);
                        byte[] imageData = memory.ToArray();

                        var newUser = new ApplicationUser
                        {
                            FirstName = applicationUser.FirstName,
                            LastName = applicationUser.LastName,
                            Email = applicationUser.Email,
                            UserName = applicationUser.Email,
                            PhoneNumber = applicationUser.PhoneNumber,
                            Image = imageData,
                        };

                        await _userManager.CreateAsync(newUser,"P@55w0rd");
                        await _userManager.AddToRoleAsync(newUser, roleName);
                        TempData["Message"] = "Record created successfully";
                        return RedirectToAction(nameof(Users));
                    }
                }
            }
            TempData["Message"] = "Error Creating Record";
            return View(nameof(Users));
        }
        [Authorize(Roles = "Superadmin, Admin")]
        [HttpGet]
        public IActionResult Roles()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var newRole = new IdentityRole()
            {
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
            };
            await _roleManager.CreateAsync(newRole);
            TempData["Message"] = "Record created successfully";
            return RedirectToAction(nameof(Roles));
        }
        [Authorize(Roles = "Superadmin, Admin")]
        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            var existingRole = await _roleManager.FindByIdAsync(Id);
            return View("EditRole", existingRole);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(string Id, string updatedName)
        {
            var existingRole = await _roleManager.FindByIdAsync(Id);
            existingRole.Name = updatedName;
            await _roleManager.UpdateAsync(existingRole);
            return RedirectToAction(nameof(Roles));
        }
    }
}
