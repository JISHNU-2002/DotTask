using Microsoft.EntityFrameworkCore;
using TaskManager.Entity.Data;
using TaskManager.Entity.Models;
using TaskManager.Service.Repository.Interface;

namespace TaskManager.Service.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }      
        
        public Task<List<Employee>> GetAllEmployeeAsync()
        {
            var employees = _context.EmployeeSet.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.EmployeeSet.FindAsync(id);
            return employee;
        }
        
        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.EmployeeSet.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.EmployeeSet.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeByIdAsync(int id)
        {
            var employee = await _context.EmployeeSet.FindAsync(id);
            _context.EmployeeSet.Remove(employee);
            await _context.SaveChangesAsync();  
        }
    }
}
