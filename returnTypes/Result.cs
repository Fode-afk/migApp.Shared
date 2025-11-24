namespace migApp.Shared.returnTypes
{
    public class Result : IResult
    {
        public string Message { get; } = string.Empty;
        public ErrorType ErrorType { get; }
        public bool IsSuccess => ErrorType == ErrorType.None;
        public bool IsFailure => !IsSuccess;

        protected Result(ErrorType errorType) => ErrorType = errorType;
        protected Result(ErrorType errorType, string message = "")
        { 
            Message = message;
            ErrorType = errorType;
        }

        public static Result Ok() => new(ErrorType.None);

        public static Result Fail(ErrorType errorType, string message) => new(errorType, message);

        public static Result NotFound(string message) => new(ErrorType.NotFound, message);

        public static Result InvalidArgument(string message) => new(ErrorType.InvalidArgument, message);

        public static Result AlreadyExists(string message) => new(ErrorType.AlreadyExists, message);

        public static Result Internal(string message) => new(ErrorType.Internal, message);
    }

    public class Result<T> : Result, IResult<T>
    {
        public T Value { get; } = default!;

        private Result(T value) : base(ErrorType.None)
        {
            Value = value;
        }

        private Result(ErrorType errorType, string message) : base(errorType, message)
        {
            Value = default!;
        }

        public static Result<T> Ok(T value) => new(value);
        public static Result<T> Fail(ErrorType errorType, string message) => new(errorType, message);

        public static Result<T> NotFound(string message) => new(ErrorType.NotFound, message);

        public static Result<T> InvalidArgument(string message) => new(ErrorType.InvalidArgument, message);

        public static Result<T> AlreadyExists(string message) => new(ErrorType.AlreadyExists, message);

        public static Result<T> Internal(string message) => new(ErrorType.Internal, message);
    }

    public enum ErrorType
    {
        None,
        NotFound,
        InvalidArgument,
        AlreadyExists,
        Internal
    }
}
