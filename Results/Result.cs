namespace migApp.Shared.Results;

public class Result : IResult
{
    public Error Error { get; }
    public bool IsSuccess => Error == Error.None;
    public bool IsFailure => !IsSuccess;

    protected Result(Error error)
    { 
        Error = error;
    }

    public static Result Ok() => new(Error.None);

    public static Result Fail(Error error) => new(error);       
}

public class Result<T> : Result, IResult<T>
{
    public T Value { get; } = default!;

    private Result(T value) : base(Error.None) => Value = value;

    private Result(Error error) : base(error) => Value = default!;

    public static Result<T> Ok(T value) => new(value);

    public static Result<T> Fail(Error error) => new(error);
}
