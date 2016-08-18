namespace AspNetCoreToDo.Web.Commands.Tasks
{
    using AspNetCoreToDo.Web.Commands;
    using MediatR;

    public class TaskDeleteCommand : SingleEntityCommandBase, IAsyncRequest<CommandResult>
    {
    }
}
