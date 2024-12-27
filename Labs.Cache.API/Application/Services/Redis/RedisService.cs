using Labs.Cache.API.Infra;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Labs.Cache.API.Application.Services.Redis
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _distributedCache;

        private static readonly JsonSerializerOptions serializerOptions = new()
        {
            PropertyNamingPolicy = null,
            WriteIndented = true,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public RedisService(IConnectionMultiplexer distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T> GetOrSetCacheValueAsync<T>(string key, Func<Task<T>> task)
        {
            var db = _distributedCache.GetDatabase();
            var json = await db.StringGetAsync(key);

            if (json.HasValue!)
                return JsonSerializer.Deserialize<T>(json!, serializerOptions)!;

            T vaue = await task();

            await SetCacheValueAsync(key, await task(), TimeSpan.FromMinutes(RedisConsts.ExpiryTime));

            return vaue;
        }

        private async Task SetCacheValueAsync<T>(string key, T value, TimeSpan expiration)
        {
            var db = _distributedCache.GetDatabase();
            var json = JsonSerializer.Serialize(value, serializerOptions);

            await db.StringSetAsync(key, json, expiration);
        }

        public async void InvalidateCache(string key)
        {
            var db = _distributedCache.GetDatabase();

            await db.StringGetDeleteAsync(key);
        }
    }
}
