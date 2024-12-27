using Labs.Cache.API.Application.Users.Dtos;
using Labs.Cache.API.Domain.Users;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.Get.MongoDb
{
    public class GetUserSummaryMongoDbHandler : IRequestHandler<GetUserSummaryQueryMongoDb, UsersSummaryDto>
    {
        private readonly IQueryUserSummaryMongoDbRepository _repository;

        public GetUserSummaryMongoDbHandler(IQueryUserSummaryMongoDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<UsersSummaryDto> Handle(GetUserSummaryQueryMongoDb request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);

            if (user == null)
                return null!;

            return new UsersSummaryDto()
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                TenantName = user.TenantName,
                RoleName = user.RoleName
            };
        }
    }
}
