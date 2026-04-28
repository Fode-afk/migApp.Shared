using migApp.Shared.Results;

namespace migApp.Shared.Domain.Errors;

public static class MoneyErrors
{
    public static Error AmountNegative() => Error.InvalidArgument(MoneyErrorCodes.AmountNegative);
    public static Error AmountTooLarge() => Error.InvalidArgument(MoneyErrorCodes.AmountTooLarge);
    public static Error DifferentCurrencies() => Error.InvalidArgument(MoneyErrorCodes.DifferentCurrencies);
    public static Error AmountHasTooManyDecimalPlaces() => Error.InvalidArgument(MoneyErrorCodes.AmountHasTooManyDecimalPlaces);
    public static Error ExchangeRateNotFound() => Error.NotFound(MoneyErrorCodes.ExchangeRateNotFound);
    public static Error InvalidPrecision() => Error.InvalidArgument(MoneyErrorCodes.InvalidPrecision);
    public static Error CurrencyIsRequired() => Error.InvalidArgument(MoneyErrorCodes.CurrencyIsRequired);
    public static Error InvalidParts() => Error.InvalidArgument(MoneyErrorCodes.InvalidParts);
}

public static class MoneyErrorCodes
{
    public const string AmountNegative = "Money.AmountNegative";
    public const string AmountTooLarge = "Money.AmountTooLarge";
    public const string DifferentCurrencies = "Money.DifferentCurrencies";
    public const string AmountHasTooManyDecimalPlaces = "Money.AmountHasTooManyDecimalPlaces";
    public const string ExchangeRateNotFound = "Money.ExchangeRateNotFound";
    public const string InvalidPrecision = "Money.InvalidPrecision";
    public const string NegativeMultiplier = "Money.NegativeMultiplier";
    public const string NegativeDivisor = "Money.NegativeDivisor";
    public const string CurrencyIsRequired = "Money.CurrencyIsRequired";
    public const string InvalidParts = "Money.InvalidParts";
}