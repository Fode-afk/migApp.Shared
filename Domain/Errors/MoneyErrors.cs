using migApp.Shared.Results;

namespace migApp.Shared.Domain.Errors;

public static class MoneyErrors
{
    public static Error AmountNegative() =>
        Error.InvalidArgument(
            MoneyErrorCodes.AmountNegative,
            "Amount must be greater than or equal to zero.");

    public static Error AmountTooLarge() =>
        Error.InvalidArgument(
            MoneyErrorCodes.AmountTooLarge,
            "Amount exceeds the maximum allowed value.");

    public static Error DifferentCurrencies() =>
        Error.InvalidArgument(
            MoneyErrorCodes.DifferentCurrencies,
            "Cannot perform operation on amounts with different currencies.");

    public static Error AmountHasTooManyDecimalPlaces() =>
        Error.InvalidArgument(
            MoneyErrorCodes.AmountHasTooManyDecimalPlaces,
            "Amount has too many decimal places for the specified currency.");

    public static Error ExchangeRateNotFound() =>
        Error.NotFound(
            MoneyErrorCodes.ExchangeRateNotFound,
            "Exchange rate not found for the specified currency pair.");

    public static Error InvalidPrecision() =>
        Error.InvalidArgument(
            MoneyErrorCodes.InvalidPrecision,
            "Precision must be a non-negative integer.");

    public static Error CurrencyIsRequired() =>
        Error.InvalidArgument(
            MoneyErrorCodes.CurrencyIsRequired,
            "Currency must be specified.");

    public static Error InvalidParts() =>
        Error.InvalidArgument(
            MoneyErrorCodes.InvalidParts,
            "Money value contains invalid or malformed parts.");
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