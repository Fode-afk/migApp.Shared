using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Embeddings;

public sealed record GenerateProductEmbeddingIntegrationEvent(Guid ProductId);
