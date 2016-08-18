namespace AspNetCoreToDo.Web.Commands.Tasks
{
    using System.Threading.Tasks;
    using AspNetCoreToDo.Web.Models;
    using MediatR;

    public class TaskDeleteCommandHandler : SingleTaskCommandHandlerBase, IAsyncRequestHandler<TaskDeleteCommand, CommandResult>
    {
        public TaskDeleteCommandHandler(ToDoContext context)
            : base(context)
        {
        }

        public async Task<CommandResult> Handle(TaskDeleteCommand command)
        {
            var task = await GetTask(command.Id);
            Context.Tasks.Remove(task);
            await Context.SaveChangesAsync();
            return CommandResult.SuccessResult();
        }
    }
}
