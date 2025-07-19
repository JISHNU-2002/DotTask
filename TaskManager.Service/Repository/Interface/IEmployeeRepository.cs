using TaskManager.Entity.Models;
namespace TaskManager.Service.Repository.Interface
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllEmployeeAsync();
        public Task<Employee> GetEmployeeByIdAsync(int id);
        public Task AddEmployeeAsync(Employee employee);
        public Task UpdateEmployeeAsync(Employee employee);
        public Task DeleteEmployeeByIdAsync(int id);
    }
}
