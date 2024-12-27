using Labs.Cache.API.Application.Services.Messaging;
using Labs.Cache.API.Application.Services.MongoDb;
using Labs.Cache.API.Application.Services.Redis;
using Labs.Cache.API.Domain.Users;
using Labs.Cache.API.Infra;
using Labs.Messaging.Events;
using MediatR;

namespace Labs.Cache.API.Application.Users.Commands.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly ICommandUserRepository _repository;

        private readonly IRedisService _cacheService;

        private readonly IMongoDbService _mongoDbService;

        private readonly IMessagingService _messagingService;

        public UpdateUserHandler(ICommandUserRepository repository, IRedisService cacheService, IMongoDbService mongoService, IMessagingService messagingService)
        {
            _repository = repository;
            _cacheService = cacheService;
            _mongoDbService = mongoService;
            _messagingService = messagingService;
        }

        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                TenantId = request.TenantId,
                RoleId = request.RoleId,
            };

            _repository.Update(user);

            _cacheService.InvalidateCache(RedisConsts.UsersSummary);
            _mongoDbService.InvalidateCache(RedisConsts.UsersSummary);
            _messagingService.SendMessage(new UserDataUpdatedEvent(), RabbitMqConsts.RabbitMqUri);

            return Task.CompletedTask;
        }
    }
}
