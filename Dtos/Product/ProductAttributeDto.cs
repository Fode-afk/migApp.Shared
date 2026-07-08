using migApp.Shared.Enums.Characteristics;
using System;
using System.Collections.Generic;

namespace migApp.Shared.Dtos.Product;

public sealed record ProductAttributeDto(
    Guid? CharacteristicId,
    string Name,
    string? Value,
    AttributeCharType CharType,
    string? GroupName,
    bool IsVariable,
    bool IsUnifying,
    List<AttributeVariableValueDto> VariableValues);

public sealed record AttributeVariableValueDto(string Value, Guid? ValueId);