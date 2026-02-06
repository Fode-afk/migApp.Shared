using migApp.Shared.returnTypes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace migApp.Shared.Caching;

public interface ICacheRepo
{
    Task<IResult<List<T>>> GetStringsAsync<T>(
        string[] keys,
        TimeSpan? slidingExpiration = null,
        bool includeNulls = false,
        CancellationToken cancellationToken = default);

    Task<IResult<T>> GetStringAsync<T>(
       string key,
       TimeSpan? slidingExpiration = null,
       CancellationToken cancellationToken = default);

    Task<IResult> SetStringsAsync<T>(
        Dictionary<string, T> data,
        TimeSpan? expiry = null,
        CancellationToken cancellationToken = default);

    Task<IResult> SetStringAsync<T>(
        string key,
        T value,
        TimeSpan? expiry = null,
        CancellationToken cancellationToken = default);


    Task<IResult<List<T>>> GetSetMembersAsync<T>(
        string key,
        TimeSpan? slidingExpiration = null,
        CancellationToken cancellationToken = default);

    Task<IResult> AddToSetAsync<T>(
        string key, 
        T value,
        TimeSpan? expiry = null,
        CancellationToken cancellationToken = default);

    Task<IResult> RemoveFromSetAsync<T>(
        string key,
        T value,
        CancellationToken cancellationToken = default);


    Task<IResult> RemoveKeysAsync(
       string[] keys,
       CancellationToken cancellationToken = default);

    Task<IResult> RemoveKeyAsync(
        string key,
        CancellationToken cancellationToken = default);
}
