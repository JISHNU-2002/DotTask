using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entity.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        [MaxLength(50)]
        public string MenuName { get; set; }
        [MaxLength(50)]
        public string ControllerName { get; set; }
        [MaxLength(50)]
        public string ActionName { get; set; }
        public bool IsActive { get; set; }
    }
}
