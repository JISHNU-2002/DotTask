using Microsoft.EntityFrameworkCore;
using TaskManager.Entity.Data;
using TaskManager.Entity.Models;
using TaskManager.Service.Repository.Interface;

namespace TaskManager.Service.Repository.Implementation
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;
        // private readonly UserManager<ApplicationUser> _userManager;
        // private readonly RoleManager<ApplicationUser> _roleManager;

        public MenuRepository(AppDbContext context)
            //UserManager<ApplicationUser> userManager,
            //RoleManager<ApplicationUser> roleManager
        {
            _context = context;
            //_userManager = userManager;
            //_roleManager = roleManager;
        }
        public async Task<List<Menu>> GetAllMenu()
        {
            return await _context.MenuSet.ToListAsync();
        }
    }
}

