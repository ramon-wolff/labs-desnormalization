using Labs.Cache.API.Application.Services.Redis;
using Labs.Cache.API.Application.Users.Dtos;
using Labs.Cache.API.Domain.Users;
using Labs.Cache.API.Infra;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.List.Redis
{
    public class GetAllUsersSummaryRedisHandler : IRequestHandler<GetAllUsersSummaryQueryRedis, List<UsersSummaryDto>>
    {
        private readonly IRedisService _cacheService;
        private readonly IQueryUserSummaryDbRepository _repository;

        public GetAllUsersSummaryRedisHandler(IRedisService cacheService, IQueryUserSummaryDbRepository repository)
        {
            _cacheService = cacheService;
            _repository = repository;
        }

        public async Task<List<UsersSummaryDto>> Handle(GetAllUsersSummaryQueryRedis request, CancellationToken cancellationToken)
        {
            var roles = await _cacheService.GetOrSetCacheValueAsync(
                    RedisConsts.UsersSummary,
                    async () =>
                    {
                        return await _repository.GetAll();
                    })!;

            return roles!.Select(x => new UsersSummaryDto()
            {
                UserId = x.UserId,
                Name = x.Name,
                Email = x.Email,
                TenantName = x.TenantName,
                RoleName = x.RoleName
            }).ToList();
        }
    }
}
