using System.Collections.Generic;

namespace migApp.Shared.Results;

public sealed record Error
{
    internal Error(
        string code,
        string message,
        ErrorType type,
        IReadOnlyDictionary<string, object> metadata = null)
    {
        Code = code;
        Message = message;
        Type = type;
        Metadata = metadata;
    }

    public string Code { get; }
    public string Message { get; }
    public ErrorType Type { get; }
    public IReadOnlyDictionary<string, object> Metadata { get; }


    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.None);

    public static Error Validation(
        string code,
        IReadOnlyDictionary<string, object> metadata) =>
            new(code, "Invalid argument", ErrorType.InvalidArgument, metadata);

    public static Error NotFound(string code, string message) =>
        new(code, message, ErrorType.NotFound);

    public static Error InvalidArgument(string code, string message) =>
        new(code, message, ErrorType.InvalidArgument);

    public static Error AlreadyExists(string code, string message) =>
        new(code, message, ErrorType.AlreadyExists);

    public static Error Unauthenticated(string code, string message) =>
        new(code, message, ErrorType.Unauthenticated);

    public static Error Internal(string code, string message) =>
        new(code, message, ErrorType.Internal);
}
