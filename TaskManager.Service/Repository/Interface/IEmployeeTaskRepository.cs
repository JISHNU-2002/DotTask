using TaskManager.Entity.Models;

namespace TaskManager.Service.Repository.Interface
{
    public interface IEmployeeTaskRepository
    {
        public Task<List<EmployeeTask>> GetAllTaskAsync();
        public Task<EmployeeTask> GetTaskByIdAsync(string id);
        public Task AddTaskAsync(EmployeeTask employeeTask);
        public Task UpdateTaskAsync(EmployeeTask employeeTask);
        public Task DeleteTaskByIdAsync(string id);
    }
}
