using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManager.Entity.Data;
using TaskManager.Entity.Security;
using TaskManager.Service.Repository.Interface;

namespace TaskManager.Service.Repository.Implementation
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SecurityRepository(AppDbContext context, 
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> CreateRoleAsync(IdentityRole role)
        {
            IdentityResult result = await _roleManager.CreateAsync(role);
            return result;
        }

        public Task DeleteRoleAsync(IdentityRole role)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityRole> GetRoleByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return role;
        }

        public async Task<List<IdentityRole>> GetRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public Task UpdateRoleAsync(IdentityRole role)
        {
            throw new NotImplementedException();
        }
    }
}
