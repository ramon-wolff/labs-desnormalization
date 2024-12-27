using Labs.Cache.Data.Sync.Data;
using Labs.Cache.Data.Sync.Domain.Users;
using Labs.Cache.Data.Sync.Infra;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Labs.Cache.Data.Sync.Services
{
    public class SynchronizeUserSummaryService : ISynchronizeUserSummaryService
    {
        private readonly IMongoDatabase _database;
        private readonly IServiceScopeFactory _service;
        private readonly ILogger<SynchronizeUserSummaryService> _logger;

        public SynchronizeUserSummaryService(IMongoClient mongoClient, IConfiguration configuration, IServiceScopeFactory serviceFactory, ILogger<SynchronizeUserSummaryService> logger)
        {
            var databaseName = configuration.GetValue<string>("MongoDbSettings:DatabaseName");

            _database = mongoClient.GetDatabase(databaseName);
            _service = serviceFactory;
            _logger = logger;
        }

        public async Task SynchronizeUserSummary(CancellationToken stoppingToken)
        {
            bool containCollection = _database.ListCollectionNames().ToList().Exists(x => x == MongoDbConsts.UsersSummaryCollection);

            if (!containCollection) // Caso não exista a operação CRUD já invalidou
            {
                _logger.LogInformation("Starting synchronization: {time}", DateTimeOffset.Now);

                await _database.CreateCollectionAsync(MongoDbConsts.UsersSummaryCollection);

                IMongoCollection<UserSummary> collection = _database.GetCollection<UserSummary>(MongoDbConsts.UsersSummaryCollection);

                using var scope = _service.CreateScope();
                using var context = scope.ServiceProvider.GetRequiredService<DataContext>();

                var users = await context.Users
                            .Include(t => t.Tenant)
                            .Include(r => r.Role)
                            .ToListAsync();

                var usersSummary = Task.FromResult(users.Select(x => new UserSummary()
                {
                    UserId = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    TenantName = x.Tenant.Name,
                    RoleName = x.Role.Name
                })).Result.ToList();

                await collection!.InsertManyAsync(usersSummary, cancellationToken: stoppingToken);

                _logger.LogInformation("Synchronization finished: {time}", DateTimeOffset.Now);
            }
        }
    }
}
