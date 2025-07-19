using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManager.Entity.Models;
using TaskManager.Entity.Security;

namespace TaskManager.Entity.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {        
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<MenuRolePermission>().HasKey(x => new { x.RoleId, x.MenuId });
        //    base.OnModelCreating(builder);
        //}

        public DbSet<Employee> EmployeeSet { get; set; }
        public DbSet<Project> ProjectSet { get; set; }
        public DbSet<Menu> MenuSet { get; set; }
        public DbSet<EmployeeTask> EmployeeTaskSet { get; set; }
        public DbSet<IdGenerator> IdGeneratorSet { get; set; }
        public DbSet<ProjectType> ProjectTypeSet { get; set; }
        public DbSet<Status> StatusSet { get; set; }
        // public DbSet<MenuRolePermission> MenuPermissionSet { get; set; }
    }
}
