namespace migApp.Shared.Dtos.ProductVariant;

public sealed record DimensionsDto(
    double Length,
    double Width,
    double Height,
    string Unit);