using AdminDashBoard.ViewModel.Admin;
using AdminDashBoard.Models.IRepository.Admin;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AdminSiteUseMVC.Controllers.Admin.AdminDetails
{
    [Authorize]

    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
                
            }
            var users = await _adminRepository.GetAllAsync();
            List<AllUsersviewModel> usersViewModel = new List<AllUsersviewModel>();
            foreach (var user in users)
            {
                usersViewModel.Add(new AllUsersviewModel(user.Id,user.Fname, user.Lname, user.UserName, user.Email));
            }
            return View(usersViewModel);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }
             var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
                return View(id);
            try
            {
                var user=await _adminRepository.GetByIdAsync(id);
                ViewBag.roles =await _adminRepository.GetAllRoleAsync(id);
                UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel(user.Id,user.Fname,user.Lname,user.UserName!,user.Email);
                return View(userDetailsViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(" ", ex.Message);
                return View(id);
            }

        }
        public async Task<IActionResult> Detailsadmin()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }
            int userId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (!ModelState.IsValid)
                return View(userId);
            try
            {
                
                var user = await _adminRepository.GetByIdAsync(userId);
                ViewBag.roles = await _adminRepository.GetAllRoleAsync(userId);
                UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel(user.Id, user.Fname, user.Lname, user.UserName!, user.Email);
                return View(userDetailsViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(" ", ex.Message);
                return View(userId);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            if (!ModelState.IsValid)
                return View(id);
            try
            {


                var user = await _adminRepository.GetByIdAsync(id);
                UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel(user.Id,user.Fname!, user.Lname, user.UserName!, user.Email!);
                return View(userDetailsViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDetailsViewModel userDetailsViewModel)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            if (!ModelState.IsValid)
                return View(userDetailsViewModel);
            try
            {
                var userUpdate=await _adminRepository.GetByIdAsync(userDetailsViewModel.Id);
              
                userUpdate.Fname = userDetailsViewModel.FirstName;
                userUpdate.Lname= userDetailsViewModel.LastName;
                userUpdate.UserName= userDetailsViewModel.UserName;
                userUpdate.Email=userDetailsViewModel.Email;
                var resualt = await _adminRepository.UpdateAsync(userUpdate);
                if(!resualt)
                {
                    ModelState.AddModelError(string.Empty,"Not Update");
                    return View(userDetailsViewModel);
                }else
                {
                    return RedirectToAction("Index");
                }
               
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(userDetailsViewModel);
            }
        }
        public async Task<IActionResult> Delete(int id) 
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            if (!ModelState.IsValid)
            {
                return View(id);
            }
            try
            {
               await _adminRepository.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }

        }
    }
    
}
