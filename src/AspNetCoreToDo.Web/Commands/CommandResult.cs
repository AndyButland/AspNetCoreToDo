namespace AspNetCoreToDo.Web.Commands
{
    public class CommandResult
    {
        public static CommandResult SuccessResult() => new CommandResult { Success = true };

        public static CommandResult FailureResult(string errorMessage) => new CommandResult { ErrorMessage = errorMessage };

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class CommandResult<T> : CommandResult
    {
        public static CommandResult<T> SuccessResult(T data) => new CommandResult<T> { Success = true, Data = data };

        public T Data { get; set; }
    }
}
