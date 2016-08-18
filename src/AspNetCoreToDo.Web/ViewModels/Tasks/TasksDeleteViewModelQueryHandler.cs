namespace AspNetCoreToDo.Web.ViewModels.Tasks
{
    using System.Threading.Tasks;
    using AspNetCoreToDo.Web.Models;
    using AutoMapper;
    using MediatR;

    public class TasksDeleteViewModelQueryHandler : SingleTaskQueryHandlerBase, IAsyncRequestHandler<TasksDeleteViewModelQuery, TasksDeleteViewModel>
    {
        public TasksDeleteViewModelQueryHandler(ToDoContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<TasksDeleteViewModel> Handle(TasksDeleteViewModelQuery query)
        {
            var model = new TasksDeleteViewModel();
            var task = await GetTask(query.Id);
            Mapper.Map(task, model);
            return model;
        }
    }
}
