using TaskManager.Entity.Models;

namespace TaskManager.Service.Repository.Interface
{
    public interface IMenuRepository
    {
        public Task<List<Menu>> GetAllMenu();
        // public Task<List<Menu>> GetMenuRolePermissionAsync(string userId);
    }
}
