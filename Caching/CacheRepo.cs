using migApp.Shared.Results;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static migApp.Shared.Results.ResultFactory;

namespace migApp.Shared.Caching;

/* public class CacheRepo(IConnectionMultiplexer connectionMultiplexer) : ICacheRepo
{
    private readonly IDatabase _db = connectionMultiplexer.GetDatabase();

    public async Task<IResult<List<T>>> GetStringsAsync<T>(
        string[] keys,
        TimeSpan? slidingExpiration = null,
        bool includeNulls = false,
        CancellationToken cancellationToken = default)
    {
        if (keys.Length == 0)
            return Ok(new List<T>());

        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var redisKeys = keys.Select(k => (RedisKey)k).ToArray();
            var values = await _db.StringGetAsync(redisKeys);

            var result = new List<T>(keys.Length);
            var keysToRefresh = slidingExpiration.HasValue
                ? new List<RedisKey>()
                : null;

            for (int i = 0; i < redisKeys.Length; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var value = values[i];

                if (value.HasValue)
                {
                    var deserialized = JsonSerializer.Deserialize<T>(value!);

                    if (deserialized is null)
                        return Internal<List<T>>("Failed to deserialize cached value");

                    result.Add(deserialized);
                    keysToRefresh?.Add(redisKeys[i]);
                }
                else if (includeNulls)
                {
                    result.Add(default!);
                }
            }

            if (keysToRefresh is { Count: > 0 })
            {
                var tasks = keysToRefresh
                    .Select(k => _db.KeyExpireAsync(k, slidingExpiration));

                if (!(await Task.WhenAll(tasks)).All(x => x))
                    return Internal<List<T>>("Failed to refresh sliding expiration");
            }

            if (result.Count == 0)
                return NotFound<List<T>>("No values found in cache");

            return Ok(result);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (JsonException)
        {
            return Internal<List<T>>("Invalid cache value format");
        }
        catch (Exception)
        {
            return Internal<List<T>>("Failed to get values from cache");
        }
    }

    public async Task<IResult<T>> GetStringAsync<T>(
        string key,
        TimeSpan? slidingExpiration = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var value = await _db.StringGetAsync(key);

            if (value.IsNullOrEmpty)
                return NotFound<T>("Value not found in cache");

            if (slidingExpiration.HasValue)
            {
                var refreshed = await _db.KeyExpireAsync(key, slidingExpiration);
                if (!refreshed)
                    return Internal<T>("Failed to refresh sliding expiration");
            }

            var result = JsonSerializer.Deserialize<T>(value!);

            if (result is null)
                return Internal<T>("Failed to deserialize cached value");

            return Ok(result);
        }
        catch (OperationCanceledException) { throw; }
        catch (JsonException)
        {
            return Internal<T>("Invalid cache value format");
        }
        catch (Exception)
        {
            return Internal<T>("Failed to get value from cache");
        }
    }

    public async Task<IResult> SetStringsAsync<T>(
        Dictionary<string, T> data,
        TimeSpan? expiry = null,
        CancellationToken cancellationToken = default)
    {
        if (data is null || data.Count == 0)
            return InvalidArgument("Data dictionary cannot be null or empty");

        if (data.Any(x => x.Value is null))
            return InvalidArgument("Null values are not allowed in cache");

        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var entries = new List<KeyValuePair<RedisKey, RedisValue>>(data.Count);

            foreach (var kv in data)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var json = JsonSerializer.Serialize(kv.Value);
                entries.Add(new KeyValuePair<RedisKey, RedisValue>(kv.Key, json));
            }

            var result = await _db.StringSetAsync([.. entries]);

            if (!result)
                return Internal("Failed to set values in cache");

            if (expiry.HasValue)
            {
                var expiryTasks = entries.Select(e => _db.KeyExpireAsync(e.Key, expiry.Value));

                if (!(await Task.WhenAll(expiryTasks)).All(x => x))
                    return Internal<List<T>>("Failed to set expiry on cached values");
            }

            return Ok();
        }
        catch (OperationCanceledException) { throw; }
        catch (JsonException)
        {
            return Internal("Failed to serialize values");
        }
        catch (Exception)
        {
            return Internal("Failed to set values in cache");
        }
    }

    public async Task<IResult> SetStringAsync<T>(
        string key,
        T value,
        TimeSpan? expiry = null,
        CancellationToken cancellationToken = default)
    {
        if (value is null)
            return InvalidArgument("Cannot cache null value");

        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var json = JsonSerializer.Serialize(value);

            var result = await _db.StringSetAsync(key, json, expiry, When.Always);

            if (!result)
                return Internal("Failed to set value in cache");

            return Ok();
        }
        catch (OperationCanceledException) { throw; }
        catch (JsonException)
        {
            return Internal("Failed to serialize value");
        }
        catch (Exception)
        {
            return Internal("Failed to set value in cache");
        }       
    }

    public async Task<IResult<List<T>>> GetSetMembersAsync<T>(
        string key,
        TimeSpan? slidingExpiration = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var members = await _db.SetMembersAsync(key);

            if (slidingExpiration.HasValue)
            {
                var refreshed = await _db.KeyExpireAsync(key, slidingExpiration.Value);
                if (!refreshed)
                    return Internal<List<T>>("Failed to refresh sliding expiration");
            }

            var result = members
                .Select(m => JsonSerializer.Deserialize<T>(m))
                .Where(x => x != null)
                .ToList();

            if (result.Count == 0)
                return NotFound<List<T>>("No set members found in cache");

            return Ok(result);
        }
        catch (OperationCanceledException) { throw; }
        catch (JsonException)
        {
            return Internal<List<T>>("Failed to deserialize value");
        }
        catch (Exception)
        {
            return Internal<List<T>>("Failed to get set members");
        }
    }

    public async Task<IResult> AddToSetAsync<T>(
        string key,
        T value,
        TimeSpan? expiry = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var json = JsonSerializer.Serialize(value);
            var added = await _db.SetAddAsync(key, json);

            if (expiry.HasValue)
            {
                var refreshed = await _db.KeyExpireAsync(key, expiry.Value);
                if (!refreshed)
                    return Internal<List<T>>("Failed to refresh sliding expiration");
            }

            return Ok();
        }
        catch (OperationCanceledException) { throw; }
        catch (JsonException)
        {
            return Internal("Failed to serialize value");
        }
        catch (Exception)
        {
            return Internal("Failed to add value to set");
        }
    }

    public async Task<IResult> RemoveFromSetAsync<T>(
        string key,
        T value,
        CancellationToken cancellationToken = default)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var json = JsonSerializer.Serialize(value);
            var removed = await _db.SetRemoveAsync(key, json);

            if (!removed)
                return NotFound("Value not found in set");

            return Ok();
        }
        catch (OperationCanceledException) { throw; }
        catch (JsonException)
        {
            return Internal("Failed to serialize value");
        }
        catch (Exception)
        {
            return Internal("Failed to remove value from set");
        }
    }

    public async Task<IResult> RemoveKeysAsync(
        string[] keys,
        CancellationToken cancellationToken = default)
    {
        if (keys == null || keys.Length == 0)
            return InvalidArgument("Keys array cannot be null or empty");

        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var redisKeys = keys.Select(k => (RedisKey)k).ToArray();

            var removedCount = await _db.KeyDeleteAsync(redisKeys);

            if (removedCount == 0)
                return NotFound("No values found in cache");

            return Ok();
        }
        catch (OperationCanceledException) { throw; }
        catch (Exception)
        {
            return Internal("Failed to remove values from cache");
        }
    }

    public async Task<IResult> RemoveKeyAsync(
        string key,
        CancellationToken cancellationToken = default)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _db.KeyDeleteAsync(key);

            if (!result)
                return NotFound("Value not found in cache");

            return Ok();
        }
        catch (OperationCanceledException) { throw; }
        catch (Exception)
        {
            return Internal("Failed to remove value from cache");
        }
    }
}
*/