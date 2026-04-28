using migApp.Shared.Domain.Errors;
using migApp.Shared.Domain.Primitives;
using migApp.Shared.Results;
using System.Collections.Generic;
using System.Linq;
using static migApp.Shared.Results.ResultFactory;

namespace migApp.Shared.Domain.ValueObjects;

public sealed class Currency : ValueObject
{
    private Currency(string code, int minorUnits)
    { 
        Code = code;
        MinorUnits = minorUnits;
    }

    public const int MaxCodeLength = 3;

    public string Code { get; }
    public int MinorUnits { get; }

    public decimal MinorFactor
    {
        get
        {
            decimal result = 1;
            for (int i = 0; i < MinorUnits; i++)
                result *= 10;
            return result;
        }
    }

    public static readonly Currency USD = new("USD", 2);
    public static readonly Currency EUR = new("EUR", 2);
    public static readonly Currency BYN = new("BYN", 2);
    public static readonly Currency RUB = new("RUB", 0);

    public static IResult<Currency> Create(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            return Fail<Currency>(CurrencyErrors.CodeIsRequired());

        if (!code.All(char.IsLetter) || code.Length > MaxCodeLength)
            return Fail<Currency>(CurrencyErrors.InvalidFormat());

        code = code.ToUpperInvariant();

        return code switch
        {
            "USD" => Ok(USD),
            "EUR" => Ok(EUR),
            "BYN" => Ok(BYN),
            "RUB" => Ok(RUB),
            _ => Fail<Currency>(CurrencyErrors.UnsupportedCurrency())
        };
    }      

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Code;
        yield return MinorUnits;
    }
}
