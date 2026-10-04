using System;
using System.Collections.Generic;

namespace migApp.Shared.Results;

public record PagedResult<T>(
    List<T> Items,
    int TotalCount, 
    int PageNumber, 
    int PageSize)
{
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}
