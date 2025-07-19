namespace TaskManager.Entity.ViewModels
{
    public class ManagerViewModel
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectType { get; set; }
        public string TaskName { get; set; }
        public int EstimatedEstimatedTime { get; set; }
        public string AssignedTo { get; set; }
    }
}
