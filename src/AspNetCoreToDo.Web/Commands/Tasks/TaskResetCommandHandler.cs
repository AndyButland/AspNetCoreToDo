namespace AspNetCoreToDo.Web.Commands.Tasks
{
    using System.Threading.Tasks;
    using AspNetCoreToDo.Web.Models;
    using MediatR;

    public class TaskResetCommandHandler : SingleTaskCommandHandlerBase, IAsyncRequestHandler<TaskResetCommand, CommandResult>
    {
        public TaskResetCommandHandler(ToDoContext context)
            : base(context)
        {
        }

        public async Task<CommandResult> Handle(TaskResetCommand command)
        {
            var task = await GetTask(command.Id);
            task.MarkIncomplete();
            await Context.SaveChangesAsync();
            return CommandResult.SuccessResult();
        }
    }
}
