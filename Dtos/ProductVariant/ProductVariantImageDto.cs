namespace migApp.Shared.Dtos.ProductVariant;

public sealed record ProductVariantImageDto(
    string Url,
    string Alt,
    int SortOrder,
    bool IsMain);