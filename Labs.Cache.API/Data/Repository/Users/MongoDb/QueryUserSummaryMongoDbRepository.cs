using Labs.Cache.API.Domain.Users;
using Labs.Cache.API.Infra;
using MongoDB.Driver;

namespace Labs.Cache.API.Data.Repository.Users.MongoDb
{
    public class QueryUserSummaryMongoDbRepository : IQueryUserSummaryMongoDbRepository
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<UserSummary> _collection;

        public QueryUserSummaryMongoDbRepository(IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase(MongoDbConsts.DatabaseName);
            _collection = _database.GetCollection<UserSummary>(MongoDbConsts.UsersSummaryCollection);
        }

        public Task<List<UserSummary>> GetAll()
        {
            return _collection.Find(Builders<UserSummary>.Filter.Empty).ToListAsync();
        }

        public Task<UserSummary> GetById(Guid id)
        {
            var filter = Builders<UserSummary>.Filter.Eq(u => u.UserId, id);
            var user = _collection.Find(filter).FirstOrDefault();

            return Task.FromResult(user);
        }
    }
}
