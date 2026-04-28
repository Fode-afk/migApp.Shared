using System;
using System.Collections.Generic;

namespace migApp.Shared.Discounts;

public abstract record DiscountTarget;

public record ProductTarget(List<Guid> ProductIds) : DiscountTarget;

public record CategoryTarget(Guid CategoryId) : DiscountTarget;

public record GlobalTarget() : DiscountTarget;