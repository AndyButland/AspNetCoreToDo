namespace AspNetCoreToDo.Web.Infrastructure.Mediator
{
    using AspNetCoreToDo.Web.Models;

    public abstract class CommandHandlerBase : HandlerBase
    {
        protected CommandHandlerBase(ToDoContext context)
            : base(context)
        {
        }
    }
}
