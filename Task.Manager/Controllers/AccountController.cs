using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Entity.Security;
using TaskManager.Entity.ViewModels;

namespace Task.Manager.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        
        public async Task<IActionResult> ListUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Credentials");
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    UserName = model.UserName,
                    Email = model.UserName,
                    IsActive = true
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(ListUsers));
                }

                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddRemoveRoles(string id)
        {
            AddRemoveRoleViewModel model = new AddRemoveRoleViewModel();
            var user = await _userManager.FindByIdAsync(id);
            model.UserId = user.Id;
            model.UserName = user.UserName;

            foreach (var role in await _roleManager.Roles.ToListAsync())
            {
                AddRemoveRole addRemoveRole = new()
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = await _userManager.IsInRoleAsync(user, role.Name)
                };
                model.AddRemoveRoles.Add(addRemoveRole);
            }
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRemoveRoles(AddRemoveRoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            IdentityResult result = new IdentityResult();

            for(int i=0; i<model.AddRemoveRoles.Count; i++)
            {
                if (model.AddRemoveRoles[i].IsSelected && !await _userManager.IsInRoleAsync(user, model.AddRemoveRoles[i].RoleName))
                {
                    result = await _userManager.AddToRoleAsync(user, model.AddRemoveRoles[i].RoleName);
                }
                else if (!model.AddRemoveRoles[i].IsSelected && await _userManager.IsInRoleAsync(user, model.AddRemoveRoles[i].RoleName))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, model.AddRemoveRoles[i].RoleName);
                }
            }

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ListUsers));
            }

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
