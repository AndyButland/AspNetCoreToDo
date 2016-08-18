namespace AspNetCoreToDo.Web.Infrastructure.Mapping
{
    using AspNetCoreToDo.Web.Commands.Tasks;
    using AspNetCoreToDo.Web.Models;
    using AspNetCoreToDo.Web.ViewModels.Tasks;
    using Profile = AutoMapper.Profile;

    public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<Task, TasksIndexViewModel.TaskListEntry>();
            CreateMap<Task, TasksEditViewModel>();
            CreateMap<Task, TasksDeleteViewModel>();

            CreateMap<TasksEditViewModel, TaskAddOrEditCommand>();
            CreateMap<TasksDeleteViewModel, TaskDeleteCommand>();
        }
    }
}
