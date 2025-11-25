using migApp.Shared.returnTypes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace migApp.Shared.Caching
{
    public interface ICacheRepo
    {
        Task<ExecutionResult<List<T?>>> GetManyAsync<T>(string[] keys, TimeSpan? slidingExpiration = null, bool includeNulls = false, CancellationToken ct = default);
        Task<ExecutionResult> SetManyAsync<T>(Dictionary<string, T> data, TimeSpan? expiry = null, CancellationToken ct = default);
        Task<ExecutionResult> SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken ct = default);
        Task<ExecutionResult> RemoveAsync(string key, CancellationToken ct = default);

        Task<ExecutionResult<List<T>>> GetSetMembersAsync<T>(string key, TimeSpan? slidingExpiration = null, CancellationToken ct = default);
        Task<ExecutionResult> AddToSetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken ct = default);
        Task<ExecutionResult> RemoveFromSetAsync<T>(string key, T value, CancellationToken ct = default);
    }
}
