using System.ComponentModel.DataAnnotations;

namespace TaskManager.Entity.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Required] public string UserName { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password Mismatch")]
        [Display(Name ="Change Password")]
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
