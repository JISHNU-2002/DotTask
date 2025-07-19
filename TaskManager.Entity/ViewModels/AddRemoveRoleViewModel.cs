namespace TaskManager.Entity.ViewModels
{
    public class AddRemoveRoleViewModel
    {
        public List<AddRemoveRole> AddRemoveRoles { get; set; } = new();
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
    public class AddRemoveRole
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
