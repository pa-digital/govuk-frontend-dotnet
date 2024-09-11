namespace GDS.Components.ViewModels
{
    using GDS.Components.Models;

    public class TaskListViewModel
    {
        public IList<TaskModel> Tasks { get; set; }

        public TaskListViewModel()
        {
            Tasks = new List<TaskModel>();
        }
    }
}
