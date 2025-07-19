using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entity.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key] 
        public int EmpId { get; set; }
        [MaxLength(50)]
        public required string EmpName { get; set; }
        [MaxLength(50)]
        public required string Email { get; set; }
        public int ProjectId { get; set; }
        public required int TaskId { get; set; }
        public bool IsAllocated {  get; set; }
    }
}
