using migApp.Shared.Domain.ValueObjects;
using System;

namespace migApp.Shared.Domain.Extensions;

public static class MoneyConversionExtensions
{
    public static long ConvertToMinor(this Money amount, Currency target, decimal rate)
    {
        if (amount.Currency == target)
            return amount.ToMinor();

        var targetMinor = Math.Round(
            amount.ToMinor() * rate * target.MinorFactor / amount.Currency.MinorFactor,
            0,
            MidpointRounding.AwayFromZero);

        return decimal.ToInt64(targetMinor);
    }
}