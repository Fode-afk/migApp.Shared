using migApp.Shared.returnTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace migApp.Shared.Caching
{
    public class NoCacheRepo : ICacheRepo
    {
        public Task<ExecutionResult<List<T?>>> GetManyAsync<T>(string[] keys, TimeSpan? slidingExpiration = null, bool includeNulls = false)
        {
            return Task.FromResult(new ExecutionResult<List<T?>>(true, string.Empty, []));
        }

        public Task<ExecutionResult> SetManyAsync<T>(Dictionary<string, T> data, TimeSpan? expiry = null)
        {
            return Task.FromResult(new ExecutionResult(true, string.Empty));
        }

        public Task<ExecutionResult> SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            return Task.FromResult(new ExecutionResult(true, string.Empty));
        }

        public Task<ExecutionResult> RemoveAsync(string key)
        {
            return Task.FromResult(new ExecutionResult(true, string.Empty));
        }

        public Task<ExecutionResult<List<T>>> GetSetMembersAsync<T>(string key, TimeSpan? slidingExpiration = null)
        {
            return Task.FromResult(new ExecutionResult<List<T?>>(true, string.Empty, []));
        }

        public Task<ExecutionResult> AddToSetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            return Task.FromResult(new ExecutionResult(true, string.Empty));
        }

        public Task<ExecutionResult> RemoveFromSetAsync<T>(string key, T value)
        {
            return Task.FromResult(new ExecutionResult(true, string.Empty));
        }       
    }
}
