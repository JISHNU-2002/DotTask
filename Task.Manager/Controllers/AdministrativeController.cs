using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Entity.ViewModels;
using TaskManager.Service.Repository.Interface;

namespace Task.Manager.Controllers
{
    public class AdministrativeController : Controller
    {
        private readonly ISecurityRepository _securityRepository;

        public AdministrativeController(ISecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }
        // GET: AdministrativeController - To List The Roles
        public async Task<ActionResult> Index()
        {
            var roles = await _securityRepository.GetRolesAsync();
            return View(roles);
        }

        // GET: AdministrativeController/Details/5
        public ActionResult Details(int id) 
        {
            return View();
        }

        // GET: AdministrativeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministrativeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateRoleViewModel model)
        {
            try
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = model.RoleName,
                };
                var result = await _securityRepository.CreateRoleAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdministrativeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdministrativeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdministrativeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministrativeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
