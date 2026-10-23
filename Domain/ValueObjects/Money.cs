using migApp.Shared.Domain.Errors;
using migApp.Shared.Domain.Primitives;
using migApp.Shared.Results;
using System;
using System.Collections.Generic;
using static migApp.Shared.Results.ResultFactory;

namespace migApp.Shared.Domain.ValueObjects;

public sealed class Money : ValueObject, IComparable<Money>
{
    public const decimal MaxAmount = 1_000_000_000_000m;

    public static Money Zero(Currency currency) => Create(0, currency).Value;

    private Money() { }
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

        if (amount > MaxAmount)
            return Fail<Money>(MoneyErrors.AmountTooLarge());

        var normalized = Normalize(amount, currency);

        if (normalized != amount)
            return Fail<Money>(MoneyErrors.InvalidPrecision());

        return Ok(new Money(normalized, currency));
    }

    private static decimal Normalize(decimal value, Currency currency) =>
        Math.Round(
            value,
            currency.MinorUnits,
            MidpointRounding.ToEven);

    public static IResult<Money> FromMinor(long minorAmount, Currency currency)
    {
        if (minorAmount < 0)
            return Fail<Money>(MoneyErrors.AmountNegative());

        return Create(minorAmount / currency.MinorFactor, currency);
    }

    public long ToMinor() => decimal.ToInt64(Amount * Currency.MinorFactor);

    public IResult<IReadOnlyList<Money>> Split(int parts)
    {
        if (parts <= 0)
            return Fail<IReadOnlyList<Money>>(MoneyErrors.InvalidParts());
       
        var minor = ToMinor();

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
        EnsureSameCurrency(left, right);
        return CreateOrThrow(left.Amount + right.Amount, left.Currency);
    }

    public static Money operator -(Money left, Money right)
    {
        EnsureSameCurrency(left, right);
        return CreateOrThrow(left.Amount - right.Amount, left.Currency);
    }

    public static Money operator *(Money money, int multiplier)
    {
        if (multiplier < 0)
            throw new InvalidOperationException(MoneyErrorCodes.NegativeMultiplier);

        return CreateOrThrow(money.Amount * multiplier, money.Currency);
    }

    public static Money operator /(Money money, int divisor)
    {
        if (divisor == 0)
            throw new DivideByZeroException();

        if (divisor < 0)
            throw new InvalidOperationException(MoneyErrorCodes.NegativeDivisor);

        return CreateOrThrow(money.Amount / divisor, money.Currency);
    }

    public static bool operator >(Money left, Money right) => left.CompareTo(right) > 0;
    public static bool operator <(Money left, Money right) => left.CompareTo(right) < 0;
    public static bool operator >=(Money left, Money right) => left.CompareTo(right) >= 0;
    public static bool operator <=(Money left, Money right) => left.CompareTo(right) <= 0;

    public int CompareTo(Money? other)
    {
        if (other is null)
            return 1;

        EnsureSameCurrency(this, other);

        return Amount.CompareTo(other.Amount);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Amount;
        yield return Currency;
    }

    private static void EnsureSameCurrency(Money left, Money right)
    {
        if (!left.Currency.Equals(right.Currency))
            throw new InvalidOperationException(MoneyErrorCodes.DifferentCurrencies);
    }

    private static Money CreateOrThrow(decimal amount, Currency currency)
    {
        var result = Create(amount, currency);
        return result.IsSuccess
            ? result.Value
            : throw new InvalidOperationException(result.Error.Code);
    }
}