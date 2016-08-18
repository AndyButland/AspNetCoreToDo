namespace AspNetCoreToDo.Web.ViewModels.Tasks
{
    using System;
    using System.Threading.Tasks;
    using AspNetCoreToDo.Web.Infrastructure.Mediator;
    using AspNetCoreToDo.Web.Models;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public abstract class SingleTaskQueryHandlerBase : QueryHandlerBase
    {
        protected SingleTaskQueryHandlerBase(ToDoContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected async Task<Models.Task> GetTask(int id)
        {
            var task = await Context.Tasks
                .SingleOrDefaultAsync(x => x.Id == id);
            if (task == null)
            {
                throw new NullReferenceException($"Task with id: {id} not found.");
            }

            return task;
        }
    }
}
