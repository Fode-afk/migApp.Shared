using System;
using System.Collections.Generic;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductTagsReplacedIntegrationEvent(
    Guid ProductId,
    List<string> Tags,
    long Version);