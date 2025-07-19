using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.EntityFrameworkCore;
using NuGet.ProjectModel;
using TaskManager.Entity.Data;
using TaskManager.Entity.Models;
using TaskManager.Entity.Security;
using TaskManager.Entity.ViewModels;

namespace Task.Manager.Controllers
{
    public class EmployeeTaskController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeTaskController(AppDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }      

        // GET: EmployeeTask
        public async Task<IActionResult> Index()
        {
            List<EmployeeTaskViewModel> query;

            if (User.IsInRole("Employee"))
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var userEmail = currentUser.Email;

                query = await (from task in _context.EmployeeTaskSet
                                   join project in _context.ProjectSet on task.ProjectId equals project.ProjectId
                                   join type in _context.ProjectTypeSet on task.ProjectTypeId equals type.ProjectTypeId
                                   join status in _context.StatusSet on task.StatusId equals status.StatusId
                                   where task.AssignedTo == userEmail
                                   select new EmployeeTaskViewModel
                                   {
                                       UserName = currentUser.UserName,
                                       TaskId = task.TaskId,
                                       TaskName = task.TaskName,
                                       ProjectId = project.ProjectId,
                                       ProjectName = project.ProjectName,
                                       ProjectTypeId = type.ProjectTypeId,
                                       ProjectTypeName = type.Type,
                                       EstimatedTime = task.EstimatedTime,
                                       CompletionTime = task.CompletionTime,
                                       StatusName = status.StatusType
                                   }).ToListAsync();
            }
            else
            {
                query = await (from task in _context.EmployeeTaskSet
                                   join project in _context.ProjectSet on task.ProjectId equals project.ProjectId
                                   join type in _context.ProjectTypeSet on task.ProjectTypeId equals type.ProjectTypeId
                                   join status in _context.StatusSet on task.StatusId equals status.StatusId
                                   join currentUser in _context.Users on task.AssignedTo equals currentUser.Email
                                   select new EmployeeTaskViewModel
                                   {
                                       UserName = currentUser.UserName,
                                       TaskId = task.TaskId,
                                       TaskName = task.TaskName,
                                       ProjectId = project.ProjectId,
                                       ProjectName = project.ProjectName,
                                       ProjectTypeId = type.ProjectTypeId,
                                       ProjectTypeName = type.Type,
                                       EstimatedTime = task.EstimatedTime,
                                       CompletionTime = task.CompletionTime,
                                       StatusName = status.StatusType
                                   }).ToListAsync();
            }        
            return View(query);
        }  

        // GET: EmployeeTask/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTask = await _context.EmployeeTaskSet
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (employeeTask == null)
            {
                return NotFound();
            }

            return View(employeeTask);
        }

        // GET: EmployeeTasks/Create
        public async Task<IActionResult> Create()
        {
            EmployeeTask employeeTask = new EmployeeTask();
            employeeTask.ProjectList = await GetProjectList();
            employeeTask.StatusList = await GetAllStatusList();
            employeeTask.UsersList = await GetAllUserList();
            employeeTask.ProjectTypeList = await GetAllProjectType();
            return View(employeeTask);
        }
        private async Task<List<SelectListItem>> GetAllStatusList()
        {
            var statuses = await _context.StatusSet.ToListAsync();
            var statusList = new List<SelectListItem>();
            foreach (var status in statuses)
            {
                statusList.Add(new SelectListItem { 
                    Text = status.StatusType, 
                    Value = status.StatusId.ToString() 
                });
            }
            return statusList;
        }
        private async Task<List<SelectListItem>> GetProjectList()
        {
            var projects = await _context.ProjectSet.ToListAsync();
            var projectList = new List<SelectListItem>();
            foreach (var project in projects)
            {
                projectList.Add(new SelectListItem
                {
                    Text = project.ProjectName,
                    Value = project.ProjectId.ToString()
                });
            }
            return projectList;
        }
        private async Task<List<SelectListItem>> GetAllProjectType()
        {
            var projects = await _context.ProjectTypeSet.ToListAsync();
            var projectList = new List<SelectListItem>();
            foreach (var project in projects)
            {
                projectList.Add(new SelectListItem
                {
                    Text = project.Type,
                    Value = project.ProjectTypeId.ToString()
                });
            }
            return projectList;
        }
        private async Task<List<SelectListItem>> GetAllUserList()
        {
            var users = await _context.Users.ToListAsync();
            var usersList = new List<SelectListItem>();
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Employee"))
                {
                    usersList.Add(new SelectListItem
                    {
                        Text = user.Email,
                        Value = user.Email
                    });
                }
            }
            return usersList;
        }

        // POST: EmployeeTask/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeTask employeeTask)
        {
            if (ModelState.IsValid)
            {
                var query = (from IdGen in _context.IdGeneratorSet
                             where IdGen.PrefixId == employeeTask.ProjectTypeId
                             select IdGen).SingleOrDefault();
                employeeTask.TaskId = query.Prefix + query.LastNo;
                query.LastNo++;

                _context.Add(employeeTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeTask);
        }


        // GET: EmployeeTask/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTask = await _context.EmployeeTaskSet.FindAsync(id);
            if (employeeTask == null)
            {
                return NotFound();
            }

            employeeTask.ProjectList = await GetProjectList();
            employeeTask.StatusList = await GetAllStatusList();
            employeeTask.UsersList = await GetAllUserList();
            employeeTask.ProjectTypeList = await GetAllProjectType();

            return View(employeeTask);
        }


        // POST: EmployeeTask/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EmployeeTask employeeTask)
        {
            if (id != employeeTask.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeTaskExists(employeeTask.TaskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeTask);
        }

        // GET: EmployeeTask/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTask = await _context.EmployeeTaskSet
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (employeeTask == null)
            {
                return NotFound();
            }

            return View(employeeTask);
        }

        // POST: EmployeeTask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employeeTask = await _context.EmployeeTaskSet.FindAsync(id);
            if (employeeTask != null)
            {
                _context.EmployeeTaskSet.Remove(employeeTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeTaskExists(string id)
        {
            return _context.EmployeeTaskSet.Any(e => e.TaskId == id);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTaskStatus(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employeeTask = await _context.EmployeeTaskSet.FindAsync(id);
            if (employeeTask == null)
            {
                return NotFound();
            }
            employeeTask.StatusList = await GetAllStatusList();  

            return View(employeeTask);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTaskStatus(string id, EmployeeTask employeeTask)
        {
            if (ModelState.IsValid)
            {
                _context.Update(employeeTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeTask);
        }
    }
}
