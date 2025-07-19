using System.ComponentModel.DataAnnotations;

namespace TaskManager.Entity.ViewModels
{
    public class EmployeeTaskViewModel
    {
        public string UserName { get; set; }
        public string TaskId { get; set; }
        [MaxLength(50)]
        public string TaskName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public int EstimatedTime { get; set; }
        public int CompletionTime { get; set; }
        public string StatusName { get; set; }
    }
}
