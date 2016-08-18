namespace AspNetCoreToDo.Web.Commands.Tasks
{
    using System.Threading.Tasks;
    using AspNetCoreToDo.Web.Models;
    using MediatR;

    public class TaskCompleteCommandHandler : SingleTaskCommandHandlerBase, IAsyncRequestHandler<TaskCompleteCommand, CommandResult>
    {
        public TaskCompleteCommandHandler(ToDoContext context)
            : base(context)
        {
        }

        public async Task<CommandResult> Handle(TaskCompleteCommand command)
        {
            var task = await GetTask(command.Id);
            task.MarkComplete();
            await Context.SaveChangesAsync();
            return CommandResult.SuccessResult();
        }
    }
}
