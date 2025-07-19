using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entity.Models
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [MaxLength(50)]
        public string ProjectName { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
