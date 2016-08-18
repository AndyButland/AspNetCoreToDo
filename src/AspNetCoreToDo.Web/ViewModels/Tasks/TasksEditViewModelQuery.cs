namespace AspNetCoreToDo.Web.ViewModels.Tasks
{
    using MediatR;

    public class TasksEditViewModelQuery : IAsyncRequest<TasksEditViewModel>
    {
        public int Id { get; set; }
    }
}
