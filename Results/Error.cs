using System.Collections.Generic;

namespace migApp.Shared.Results;

public sealed record Error
{
    internal Error(string code, ErrorType type, IReadOnlyDictionary<string, object> metadata = null)
    {
        Code = code;
        Type = type;
        Metadata = metadata;
    }

    public string Code { get; }
    public ErrorType Type { get; }
    public IReadOnlyDictionary<string, object> Metadata { get; }


    public static readonly Error None = new(string.Empty, ErrorType.None);

    public static Error Validation(
        string code,
        IReadOnlyDictionary<string, object> metadata) =>
            new(code, ErrorType.InvalidArgument, metadata);

    public static Error NotFound(string code) =>
        new(code, ErrorType.NotFound);

    public static Error InvalidArgument(string code) =>
        new(code, ErrorType.InvalidArgument);

    public static Error AlreadyExists(string code) =>
        new(code, ErrorType.AlreadyExists);

    public static Error Unauthenticated(string code) =>
        new(code, ErrorType.Unauthenticated);

    public static Error Internal(string code) =>
        new(code, ErrorType.Internal);
}
