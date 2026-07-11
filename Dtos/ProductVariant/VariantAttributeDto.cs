#nullable enable

using migApp.Shared.Enums.Characteristics;
using System;

namespace migApp.Shared.Dtos.ProductVariant;

public sealed record VariantAttributeDto(
    Guid CharacteristicId,
    string Name,
    string Value,
    AttributeCharType CharType,
    string? GroupName);