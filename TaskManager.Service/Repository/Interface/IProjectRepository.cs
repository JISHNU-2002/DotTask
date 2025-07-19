using TaskManager.Entity.Models;

namespace TaskManager.Service.Repository.Interface
{
    public interface IProjectRepository
    {
        public Task<List<Project>> GetAllProjectAsync();
        public Task<Project> GetProjectByIdAsync(int id);
        public Task AddProjectAsync(Project project);
        public Task UpdateProjectAsync(Project project);
        public Task DeleteProjectByIdAsync(int id);
    }
}
