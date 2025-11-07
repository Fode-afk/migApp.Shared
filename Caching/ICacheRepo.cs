using migApp.Shared.returnTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace migApp.Shared.Caching
{
    public interface ICacheRepo
    {
        Task<ExecutionResult<List<T?>>> GetManyAsync<T>(string[] keys, TimeSpan? slidingExpiration = null);
        Task<ExecutionResult> SetManyAsync<T>(Dictionary<string, T> data, TimeSpan? expiry = null);
        Task<ExecutionResult> SetAsync<T>(string key, T value, TimeSpan? expiry = null);
        Task<ExecutionResult> RemoveAsync(string key);
    }
}
