using Microsoft.Extensions.Caching.Distributed;
using PokeGame.Core.Common.Services.Models;

namespace PokeGame.Core.Common.Services.Abstract;


public interface ICachingService
{
    Task<T?> TryGetObjectAsync<T>(string key)
        where T : class;
    Task<string> SetObjectAsync<T>(
        string key,
        T value,
        CacheObjectTimeToLiveInSeconds timeToLive = CacheObjectTimeToLiveInSeconds.TenMinutes
    )
        where T : class;
    Task<string> SetObjectAsync<T>(string key, T value, DistributedCacheEntryOptions options)
        where T : class;
}
