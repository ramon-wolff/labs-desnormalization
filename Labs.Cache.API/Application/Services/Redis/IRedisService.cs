namespace Labs.Cache.API.Application.Services.Redis
{
    public interface IRedisService
    {
        Task<T> GetOrSetCacheValueAsync<T>(string key, Func<Task<T>> task);

        void InvalidateCache(string key);
    }
}
