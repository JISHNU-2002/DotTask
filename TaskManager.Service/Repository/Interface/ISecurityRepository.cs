using Microsoft.AspNetCore.Identity;

namespace TaskManager.Service.Repository.Interface
{
    public interface ISecurityRepository
    {
        public Task<List<IdentityRole>> GetRolesAsync();
        public Task<IdentityRole> GetRoleByIdAsync(string id);
        public Task<IdentityResult> CreateRoleAsync(IdentityRole role);
        public Task DeleteRoleAsync(IdentityRole role);
        public Task UpdateRoleAsync(IdentityRole role);
    }
}
