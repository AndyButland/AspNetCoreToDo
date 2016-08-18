namespace AspNetCoreToDo.Web.Infrastructure.Mediator
{
    using AspNetCoreToDo.Web.Models;

    public abstract class HandlerBase
    {
        protected HandlerBase(ToDoContext context)
        {
            Context = context;
        }

        protected ToDoContext Context { get; private set; }
    }
}
