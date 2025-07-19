using Microsoft.EntityFrameworkCore;
using TaskManager.Entity.Data;
using TaskManager.Entity.Models;
using TaskManager.Service.Repository.Interface;

namespace TaskManager.Service.Repository.Implementation
{
    public class EmployeeTaskRepository : IEmployeeTaskRepository
    {
        private readonly AppDbContext _context;

        public EmployeeTaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddTaskAsync(EmployeeTask employeeTask)
        {
            _context.EmployeeTaskSet.Add(employeeTask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskByIdAsync(string id)
        {
            var employeeTask = await _context.EmployeeTaskSet.FindAsync(id);
            _context.EmployeeTaskSet.Remove(employeeTask);
            await _context.SaveChangesAsync();
        }

        public Task<List<EmployeeTask>> GetAllTaskAsync()
        {
            var tasks = _context.EmployeeTaskSet.ToListAsync();
            return tasks;
        }

        public async Task<EmployeeTask> GetTaskByIdAsync(string id)
        {
            var task = await _context.EmployeeTaskSet.FindAsync(id);
            return task;
        }

        public async Task UpdateTaskAsync(EmployeeTask employeeTask)
        {
            _context.EmployeeTaskSet.Update(employeeTask);
            await _context.SaveChangesAsync();
        }
    }
}
