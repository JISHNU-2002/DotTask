using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskManager.Entity.Models
{
    [Table("Task")]
    public class EmployeeTask
    {
        [Key]
        [MaxLength(50)]
        public string TaskId { get; set; }
        [MaxLength(50)]
        public string TaskName { get; set; }
        public int ProjectId { get; set; }
        public int ProjectTypeId { get; set; }
        public int EstimatedTime { get; set; }
        public int CompletionTime { get; set; }
        public int StatusId { get; set; }
        [MaxLength(50)]
        public string AssignedTo { get; set; }

        [NotMapped]
        public List<SelectListItem>? UsersList { get; set; }

        [NotMapped]

        public List<SelectListItem>? StatusList { get; set; }

        [NotMapped]
        public List<SelectListItem>? ProjectList { get; set; }

        [NotMapped]
        public List<SelectListItem>? ProjectTypeList { get; set; }

    }
}
