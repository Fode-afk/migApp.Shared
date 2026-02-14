namespace migApp.Shared.Results;

public interface IResult
{
    Error Error { get; }
    bool IsSuccess { get; }
    bool IsFailure { get; }
}

public interface IResult<out T> : IResult
{
    T Value { get; }
}
