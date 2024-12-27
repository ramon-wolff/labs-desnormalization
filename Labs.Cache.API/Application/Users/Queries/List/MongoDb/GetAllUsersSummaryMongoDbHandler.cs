using Labs.Cache.API.Application.Users.Dtos;
using Labs.Cache.API.Domain.Users;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.List.MongoDb
{
    public class GetAllUsersSummaryMongoDbHandler : IRequestHandler<GetAllUsersSummaryQueryMongoDb, List<UsersSummaryDto>>
    {
        private readonly IQueryUserSummaryMongoDbRepository _repository;

        public GetAllUsersSummaryMongoDbHandler(IQueryUserSummaryMongoDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UsersSummaryDto>> Handle(GetAllUsersSummaryQueryMongoDb request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAll();

            return users!.Select(x => new UsersSummaryDto()
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
