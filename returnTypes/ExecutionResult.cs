namespace migApp.Shared.returnTypes
{
    public record ExecutionResult(bool success, string message);
    public record ExecutionResult<T>(bool success, string message, T Value);
}
