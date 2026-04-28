using migApp.Shared.Results;

namespace migApp.Shared.Domain.Errors;

public static class CurrencyErrors
{
    public static Error CodeIsRequired() => Error.InvalidArgument(CurrencyErrorCodes.CodeIsRequired);
    public static Error UnsupportedCurrency() => Error.InvalidArgument(CurrencyErrorCodes.UnsupportedCurrency);
    public static Error InvalidFormat() => Error.InvalidArgument(CurrencyErrorCodes.InvalidFormat);
}

public static class CurrencyErrorCodes
{
    public const string CodeIsRequired = "Currency.CodeIsRequired";
    public const string UnsupportedCurrency = "Currency.UnsupportedCurrency";
    public const string InvalidFormat = "Currency.InvalidFormat";
}
