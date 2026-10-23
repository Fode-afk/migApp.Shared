using migApp.Shared.Domain.Errors;
using migApp.Shared.Domain.Primitives;
using migApp.Shared.Results;
using System.Collections.Generic;
using System.Linq;
using static migApp.Shared.Results.ResultFactory;

namespace migApp.Shared.Domain.ValueObjects;

public sealed class Currency : ValueObject
{
    private Currency() { }
    private Currency(string code, int minorUnits)
    { 
        Code = code;
        MinorUnits = minorUnits;
        MinorFactor = Pow10(minorUnits);
    }

    public const int CodeLength = 3;

    public string Code { get; }
    public int MinorUnits { get; }
    public decimal MinorFactor { get; }

    private static decimal Pow10(int digits)
    {
        var result = 1m;
        for (var i = 0; i < digits; i++)
            result *= 10m;
        return result;
    }

    public static readonly Currency USD = new("USD", 2);
    public static readonly Currency EUR = new("EUR", 2);
    public static readonly Currency BYN = new("BYN", 2);
    public static readonly Currency RUB = new("RUB", 2);

    private static readonly IReadOnlyDictionary<string, Currency> _supported =
        new[] { USD, EUR, BYN, RUB }.ToDictionary(c => c.Code);
    public static IReadOnlyCollection<Currency> All => [.. _supported.Values];

    public static IResult<Currency> Create(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            return Fail<Currency>(CurrencyErrors.CodeIsRequired());

        code = code.Trim();

        if (code.Length != CodeLength || !code.All(char.IsAsciiLetter))
            return Fail<Currency>(CurrencyErrors.InvalidFormat());

        return _supported.TryGetValue(code.ToUpperInvariant(), out var currency)
            ? Ok(currency)
            : Fail<Currency>(CurrencyErrors.UnsupportedCurrency());
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Code;
    }

    public override string ToString() => Code;
    public static implicit operator string(Currency currency) => currency.ToString();
}