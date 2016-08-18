namespace AspNetCoreToDo.Web.ViewModels.Tasks
{
    using System.Linq;
    using System.Threading.Tasks;
    using AspNetCoreToDo.Web.Models;
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class TasksEditViewModelQueryHandler : SingleTaskQueryHandlerBase, IAsyncRequestHandler<TasksEditViewModelQuery, TasksEditViewModel>
    {
        public TasksEditViewModelQueryHandler(ToDoContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<TasksEditViewModel> Handle(TasksEditViewModelQuery query)
        {
            var model = new TasksEditViewModel();
            if (query.Id > 0)
            {
                var task = await GetTask(query.Id);
                Mapper.Map(task, model);
            }

            model.CategoryOptions = new SelectList(await Context.Categories
                .OrderBy(x => x.Name)
                .ToListAsync(), "Id", "Name", model.CategoryId);

            return model;
        }
    }
}
