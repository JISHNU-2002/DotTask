using Microsoft.AspNetCore.Identity;

namespace TaskManager.Entity.Security
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
