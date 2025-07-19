using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Entity.Models;
using TaskManager.Service.Repository.Interface;

namespace Task.Manager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
           _repository = repository;
        }
        // GET: EmployeeController
        public async Task<IActionResult> Index()
        {
            var employees = await _repository.GetAllEmployeeAsync(); 
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            try
            {
                await _repository.AddEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateEmployeeAsync(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: EmployeeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.DeleteEmployeeByIdAsync(id);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }
    }
}
