namespace migApp.Shared.Results;

public static class ResultFactory
{
    public static IResult Ok() => Result.Ok();
    public static IResult Fail(Error error) => Result.Fail(error);
    public static IResult<T> Ok<T>(T value) => Result<T>.Ok(value);
    public static IResult<T> Fail<T>(Error error) => Result<T>.Fail(error);
}
