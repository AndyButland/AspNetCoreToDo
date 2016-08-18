namespace AspNetCoreToDo.Web.ViewModels.Tasks
{
    using MediatR;

    public class TasksIndexViewModelQuery : IAsyncRequest<TasksIndexViewModel>
    {
        public int? CategoryId { get; set; }
    }
}
