using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entity.Models
{
    [Table("ProjectType")]
    public class ProjectType
    {
        [Key]
        public int ProjectTypeId { get; set; }
        [MaxLength(50)]
        [Required] public string Type {  get; set; }
    }
}
