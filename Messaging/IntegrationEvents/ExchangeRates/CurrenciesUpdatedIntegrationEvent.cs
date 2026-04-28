using System.Collections.Generic;

namespace migApp.Shared.Messaging.IntegrationEvents.ExchangeRates;

public sealed record CurrenciesUpdatedIntegrationEvent(Dictionary<string, decimal> Rates);