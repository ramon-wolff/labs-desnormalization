using Labs.Cache.API.Infra;
using MongoDB.Driver;

namespace Labs.Cache.API.Application.Services.MongoDb
{
    public class MongoDbService : IMongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase(MongoDbConsts.DatabaseName);
        }

        public async void InvalidateCache(string collection)
        {
            await _database.DropCollectionAsync(collection);
        }
    }
}
