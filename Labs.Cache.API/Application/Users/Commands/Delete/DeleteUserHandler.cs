using Labs.Cache.API.Application.Services.Messaging;
using Labs.Cache.API.Application.Services.MongoDb;
using Labs.Cache.API.Application.Services.Redis;
using Labs.Cache.API.Domain.Users;
using Labs.Cache.API.Infra;
using Labs.Messaging.Events;
using MediatR;

namespace Labs.Cache.API.Application.Users.Commands.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly ICommandUserRepository _commandUserRepository;

        private readonly IQueryUserRepository _queryUserRepository;
        
        private readonly IRedisService _cacheService;

        private readonly IMongoDbService _mongoDbService;

        private readonly IMessagingService _messagingService;

        public DeleteUserHandler(ICommandUserRepository commandUserRepository, IQueryUserRepository queryUserRepository, IRedisService cacheService, IMongoDbService mongoService, IMessagingService messagingService)
        {
            _commandUserRepository = commandUserRepository;
            _queryUserRepository = queryUserRepository;
            _cacheService = cacheService;
            _mongoDbService = mongoService;
            _messagingService = messagingService;
        }

        public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _queryUserRepository.GetById(request.Id);

            if (user.Result == null)
                return Task.CompletedTask;

            _commandUserRepository.Delete(user.Result);

            _cacheService.InvalidateCache(RedisConsts.UsersSummary);
            _mongoDbService.InvalidateCache(RedisConsts.UsersSummary);
            _messagingService.SendMessage(new UserDataUpdatedEvent(), RabbitMqConsts.RabbitMqUri);

            return Task.CompletedTask;
        }
    }
}
