namespace Labs.Cache.API.Application.Services.MongoDb
{
    public interface IMongoDbService
    {
        void InvalidateCache(string collection);
    }
}
