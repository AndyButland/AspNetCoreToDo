namespace AspNetCoreToDo.Web.Commands.Tasks
{
    using System;
    using System.Threading.Tasks;
    using AspNetCoreToDo.Web.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class TaskAddOrEditCommandHandler : SingleTaskCommandHandlerBase, IAsyncRequestHandler<TaskAddOrEditCommand, CommandResult<int>>
    {
        public TaskAddOrEditCommandHandler(ToDoContext context)
            : base(context)
        {
        }

        public async Task<CommandResult<int>> Handle(TaskAddOrEditCommand command)
        {
            var category = await GetCategory(command.CategoryId);
            Models.Task task;
            if (command.IsAdding)
            {
                task = new Models.Task(command.Description, category);
                Context.Tasks.Add(task);
            }
            else
            {
                task = await GetTask(command.Id);
                task.SetDetails(command.Description, category);
            }

            await Context.SaveChangesAsync();

            return CommandResult<int>.SuccessResult(task.Id);
        }

        private async Task<Category> GetCategory(int id)
        {
            var task = await Context.Categories
                .SingleOrDefaultAsync(x => x.Id == id);
            if (task == null)
            {
                throw new NullReferenceException($"Category with id: {id} not found.");
            }

            return task;
        }
    }
}
