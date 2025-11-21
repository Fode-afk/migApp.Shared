using migApp.Shared.returnTypes;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace migApp.Shared.Caching
{
    public class CacheRepo(IConnectionMultiplexer connectionMultiplexer) : ICacheRepo
    {
        private readonly IDatabase _db = connectionMultiplexer.GetDatabase();

        public async Task<ExecutionResult<List<T?>>> GetManyAsync<T>(string[] keys, TimeSpan? slidingExpiration = null, bool includeNulls = false)
        {
            try
            {
                var redisKeys = keys.Select(k => (RedisKey)k).ToArray();
                var values = await _db.StringGetAsync(redisKeys);

                var result = new List<T?>();

                for (int i = 0; i < redisKeys.Length; i++)
                {
                    var value = values[i];
                    if (value.HasValue)
                    {
                        result.Add(JsonSerializer.Deserialize<T>(value!));

                        if (slidingExpiration != null)
                            await _db.KeyExpireAsync(redisKeys[i], slidingExpiration);
                    }
                    else if (includeNulls)
                    {
                        result.Add(default);
                    }
                }

                if (result.Count == 0)
                    return new ExecutionResult<List<T?>>(false, string.Empty, null);

                return new ExecutionResult<List<T?>>(true, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ExecutionResult<List<T?>>(false, ex.Message, null);
            }
        }

        public async Task<ExecutionResult> SetManyAsync<T>(Dictionary<string, T> data, TimeSpan? expiry = null)
        {
            try
            {
                if (data == null || data.Count == 0)
                    return new ExecutionResult(false, "No data to cache");

                var entries = new List<KeyValuePair<RedisKey, RedisValue>>(data.Count);

                foreach (var kv in data)
                {
                    var json = JsonSerializer.Serialize(kv.Value);
                    entries.Add(new KeyValuePair<RedisKey, RedisValue>(kv.Key, json));
                }

                await _db.StringSetAsync([.. entries]);

                if (expiry.HasValue)
                {
                    var expiryTasks = entries.Select(e => _db.KeyExpireAsync(e.Key, expiry.Value));
                    await Task.WhenAll(expiryTasks);
                }

                return new ExecutionResult(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new ExecutionResult(false, ex.Message);
            }
        }

        public async Task<ExecutionResult> SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            try
            {
                var json = JsonSerializer.Serialize(value);

                var res = await _db.StringSetAsync(key, json, expiry, When.Always);

                return new ExecutionResult(res, string.Empty);
            }
            catch (Exception ex)
            {
                return new ExecutionResult(false, ex.Message);
            }           
        }

        public async Task<ExecutionResult> RemoveAsync(string key)
        {
            try
            {
                var res = await _db.KeyDeleteAsync(key);

                if (res)
                    return new ExecutionResult(res, string.Empty);

                return new ExecutionResult(res, "Couldn't find object in cache");
            }
            catch (Exception ex)
            {
                return new ExecutionResult(false, ex.Message);
            }
        }

        public async Task<ExecutionResult<List<T>>> GetSetMembersAsync<T>(string key, TimeSpan? slidingExpiration = null)
        {
            try
            {
                var members = await _db.SetMembersAsync(key);

                if (slidingExpiration.HasValue)
                    await _db.KeyExpireAsync(key, slidingExpiration.Value);

                var result = members
                    .Select(m => JsonSerializer.Deserialize<T>(m))
                    .Where(x => x != null)
                    .ToList();

                if (result.Count == 0)
                    return new ExecutionResult<List<T>>(false, string.Empty, null);

                return new ExecutionResult<List<T>>(true, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ExecutionResult<List<T>>(false, ex.Message, null);
            }
        }

        public async Task<ExecutionResult> AddToSetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            try
            {
                var json = JsonSerializer.Serialize(value);
                var added = await _db.SetAddAsync(key, json);

                if (expiry.HasValue)
                    await _db.KeyExpireAsync(key, expiry.Value);

                return new ExecutionResult(added, string.Empty);
            }
            catch (Exception ex)
            {
                return new ExecutionResult(false, ex.Message);
            }
        }

        public async Task<ExecutionResult> RemoveFromSetAsync<T>(string key, T value)
        {
            try
            {
                var json = JsonSerializer.Serialize(value);
                var removed = await _db.SetRemoveAsync(key, json);

                return new ExecutionResult(removed, string.Empty);
            }
            catch (Exception ex)
            {
                return new ExecutionResult(false, ex.Message);
            }
        }
    }
}
