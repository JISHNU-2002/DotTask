using System.ComponentModel.DataAnnotations;

namespace TaskManager.Entity.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required] public string UserName { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
