using Labs.Cache.API.Application.Users.Dtos;
using Labs.Cache.API.Domain.Users;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.List.Db
{
    public class GetAllUsersSummaryDbHandler : IRequestHandler<GetAllUsersSummaryDbQuery, List<UsersSummaryDto>>
    {
        private readonly IQueryUserSummaryDbRepository _repository;

        public GetAllUsersSummaryDbHandler(IQueryUserSummaryDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UsersSummaryDto>> Handle(GetAllUsersSummaryDbQuery request, CancellationToken cancellationToken)
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
