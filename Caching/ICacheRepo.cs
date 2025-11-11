using migApp.Shared.returnTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace migApp.Shared.Caching
{
    public interface ICacheRepo
    {
        Task<ExecutionResult<List<T?>>> GetManyAsync<T>(string[] keys, TimeSpan? slidingExpiration = null, bool includeNulls = false);
        Task<ExecutionResult> SetManyAsync<T>(Dictionary<string, T> data, TimeSpan? expiry = null);
        Task<ExecutionResult> SetAsync<T>(string key, T value, TimeSpan? expiry = null);
        Task<ExecutionResult> RemoveAsync(string key);

        Task<ExecutionResult<List<T>>> GetSetMembersAsync<T>(string key, TimeSpan? slidingExpiration = null);
        Task<ExecutionResult> AddToSetAsync<T>(string key, T value, TimeSpan? expiry = null);
        Task<ExecutionResult> RemoveFromSetAsync<T>(string key, T value);
    }
}
