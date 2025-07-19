using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entity.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        [MaxLength(50)]
        public required string StatusType { get; set; }
    }
}
