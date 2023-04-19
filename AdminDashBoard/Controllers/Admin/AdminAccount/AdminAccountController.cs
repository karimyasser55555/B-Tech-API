using AdminDashBoard.ViewModel.Admin;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AdminSiteUseMVC.Controllers.Admin.AdminAccount
{
    public class AdminAccountController : Controller
    {
        private readonly UserManager<User> _adminManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;


        public AdminAccountController(UserManager<User> adminManager, RoleManager<Role> roleManager,SignInManager<User> signInManager)//, IAdminAccountRepository adminAccountRepository)
        {
             _adminManager = adminManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        [Authorize]
        public string GetString()
        {
            return "Ok";
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([FromForm] RegistrationModel registrationModel)
        {
          if(!ModelState.IsValid)
                return View(registrationModel);
            try
            {
                if (await _adminManager.FindByEmailAsync(registrationModel.Email) != null)
                {
                    ModelState.AddModelError(string.Empty, "Email Is Already Registered!");
                    return View(registrationModel);
                }
                    
                if (await _adminManager.FindByNameAsync(registrationModel.UserName) != null)
                {
                    ModelState.AddModelError(string.Empty, "UserName Is Already Registered!");
                    return View(registrationModel);
                }
                User _user = registrationModel.ToModel();
                var result = await _adminManager.CreateAsync(_user, registrationModel.Password);
                if (!result.Succeeded)
                {
                    //var errors = string.Empty;
                    foreach (var error in result.Errors)
                    {
                        //errors += $"{error.Description},";
                        ModelState.AddModelError(" ", error.Description);
                    }

                    return View(registrationModel);
                }
               await _signInManager.SignInAsync(_user, true);

                await _adminManager.AddToRoleAsync(_user, "Admin");
                return RedirectToAction("Index", "Home");

            }
            catch(Exception ex)
            {
                ModelState.AddModelError(" ", ex.Message);
                return View(registrationModel);
            }
        }
      
        [HttpGet]
        public IActionResult LogIN()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIN([FromForm] LoginModel loginModel)
        {
          if(!ModelState.IsValid)
                return View(loginModel);
            try
            {
                var _user = await _adminManager.FindByNameAsync(loginModel.UserName);


                if (_user is null)
                {
                    ModelState.AddModelError(string.Empty,"UserName  is incorrect!");
                    return View(loginModel);

                }

                if (!await _adminManager.CheckPasswordAsync(_user, loginModel.Password))
                {
                    ModelState.AddModelError(string.Empty, " Password is incorrect!");
                    return View(loginModel);

                }
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, true, true);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                   // return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login");
                    return View(loginModel);
                }

            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return View(loginModel);
            }
           
        }
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel addRoleModel)
        {
            var _user = await _adminManager.FindByIdAsync(addRoleModel.UserId.ToString());
            if (_user is null || !await _roleManager.RoleExistsAsync(addRoleModel.RoleName))
                return View("Invalid User Id or Role Nmae");

            if (await _adminManager.IsInRoleAsync(_user, addRoleModel.RoleName))
                return View("User already assigned to this role");

            var result = await _adminManager.AddToRoleAsync(_user, addRoleModel.RoleName);
            if (!result.Succeeded)
                return View("Sonething went wrong");

            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(LogIN));
        }
    }
}
