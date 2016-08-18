namespace AspNetCoreToDo.Web.Commands.Tasks
{
    using AspNetCoreToDo.Web.Commands;
    using MediatR;

    public class TaskAddOrEditCommand : AddOrEditSingleEntityCommandBase, IAsyncRequest<CommandResult<int>>
    {
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
