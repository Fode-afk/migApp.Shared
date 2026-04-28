using migApp.Shared.Domain.Errors;
using migApp.Shared.Domain.Primitives;
using migApp.Shared.Results;
using System;
using System.Collections.Generic;
using static migApp.Shared.Results.ResultFactory;

namespace migApp.Shared.Domain.ValueObjects;

public sealed class Money : ValueObject
{
    public static Money Zero(Currency currency) => Create(0, currency).Value;

    private Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; }
    public Currency Currency { get; }

    public static IResult<Money> Create(decimal amount, Currency currency)
    {
        if (currency is null)
            return Fail<Money>(MoneyErrors.CurrencyIsRequired());

        if (amount < 0)
            return Fail<Money>(MoneyErrors.AmountNegative());

        var normalized = Normalize(amount, currency);

        if (normalized != amount)
            return Fail<Money>(MoneyErrors.InvalidPrecision());

        return Ok(new Money(normalized, currency));
    }

    private static decimal Normalize(decimal value, Currency currency) =>
        Math.Round(
            value,
            currency.MinorUnits,
            MidpointRounding.ToEven
        );

    public static IResult<Money> FromMinor(long minorAmount, Currency currency)
    {
        if (minorAmount < 0)
            return Fail<Money>(MoneyErrors.AmountNegative());

        return Create(minorAmount / currency.MinorFactor, currency);
    }

    public static IResult<long> ToMinor(decimal amount, Currency currency)
    {
        if (amount < 0)
            return Fail<long>(MoneyErrors.AmountNegative());

        var factor = currency.MinorFactor;

        var normalized = Normalize(amount, currency);

        if (normalized != amount)
            return Fail<long>(MoneyErrors.AmountHasTooManyDecimalPlaces());

        try
        {
            checked
            {
                return Ok((long)Math.Round(normalized * factor, 0, MidpointRounding.ToEven));
            }
        }
        catch (OverflowException)
        {
            return Fail<long>(MoneyErrors.AmountTooLarge());
        }
    }

    public IResult<IReadOnlyList<Money>> Split(int parts)
    {
        if (parts <= 0)
            return Fail<IReadOnlyList<Money>>(MoneyErrors.InvalidParts());

        var minorResult = ToMinor(Amount, Currency);
        if (minorResult.IsFailure)
            return Fail<IReadOnlyList<Money>>(minorResult.Error);

        var minor = minorResult.Value;

        var basePart = minor / parts;
        var remainder = minor % parts;

        var result = new List<Money>(parts);

        for (int i = 0; i < parts; i++)
        {
            var value = basePart + (i < remainder ? 1 : 0);
            result.Add(FromMinor(value, Currency).Value);
        }

        return Ok(result);
    }

    public static Money operator +(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            throw new InvalidOperationException(MoneyErrorCodes.DifferentCurrencies);

        var result = Create(left.Amount + right.Amount, left.Currency);

        if (result.IsFailure)
            throw new InvalidOperationException(result.Error.Code);

        return result.Value;
    }

    public static Money operator -(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            throw new InvalidOperationException(MoneyErrorCodes.DifferentCurrencies);

        if (left < right)
            throw new InvalidOperationException(MoneyErrorCodes.AmountNegative);

        var result = Create(left.Amount - right.Amount, left.Currency);

        if (result.IsFailure)
            throw new InvalidOperationException(result.Error.Code);

        return result.Value;
    }

    public static Money operator *(Money money, int multiplier)
    {
        if (multiplier < 0)
            throw new InvalidOperationException(MoneyErrorCodes.NegativeMultiplier);

        var result = Create(money.Amount * multiplier, money.Currency);

        if (result.IsFailure)
            throw new InvalidOperationException(result.Error.Code);

        return result.Value;
    }

    public static Money operator /(Money money, int divisor)
    {
        if (divisor == 0)
            throw new DivideByZeroException();

        if (divisor < 0)
            throw new InvalidOperationException(MoneyErrorCodes.NegativeDivisor);

        var raw = money.Amount / divisor;

        var result = Create(raw, money.Currency);

        if (result.IsFailure)
            throw new InvalidOperationException(result.Error.Code);

        return result.Value;
    }

    public static bool operator >(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            throw new InvalidOperationException(MoneyErrorCodes.DifferentCurrencies);

        return left.Amount > right.Amount;
    }

    public static bool operator <(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            throw new InvalidOperationException(MoneyErrorCodes.DifferentCurrencies);

        return left.Amount < right.Amount;
    }

    public static bool operator >=(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            throw new InvalidOperationException(MoneyErrorCodes.DifferentCurrencies);

        return left.Amount >= right.Amount;
    }

    public static bool operator <=(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            throw new InvalidOperationException(MoneyErrorCodes.DifferentCurrencies);

        return left.Amount <= right.Amount;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Amount;
        yield return Currency;
    }
}
