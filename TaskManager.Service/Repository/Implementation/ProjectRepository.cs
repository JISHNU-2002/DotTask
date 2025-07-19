using Microsoft.EntityFrameworkCore;
using TaskManager.Entity.Data;
using TaskManager.Entity.Models;
using TaskManager.Service.Repository.Interface;

namespace TaskManager.Service.Repository.Implementation
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Project>> GetAllProjectAsync()
        {
            var projects = _context.ProjectSet.ToListAsync();
            return projects;
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var project = await _context.ProjectSet.FindAsync(id);
            return project;
        }

        public async Task AddProjectAsync(Project project)
        {
            _context.ProjectSet.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.ProjectSet.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectByIdAsync(int id)
        {
            var project = await _context.ProjectSet.FindAsync(id);
            _context.ProjectSet.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
