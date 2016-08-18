namespace AspNetCoreToDo.Web.ViewModels.Tasks
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class TasksIndexViewModel : ListViewModelBase<TasksIndexViewModel.TaskListEntry>
    {
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        public SelectList CategoryOptions { get; set; }

        public class TaskListEntry
        {
            public int Id { get; set; }

            public string Description { get; set; }

            public bool IsComplete { get; set; }

            public string CategoryName { get; set; }
        }
    }
}
