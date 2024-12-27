using Labs.Cache.API.Application.Users.Dtos;
using Labs.Cache.API.Domain.Users;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.List.MaterializedView
{
    public class GetAllUsersSummaryMaterializedViewHandler : IRequestHandler<GetAllUsersSummaryQueryMaterializedView, List<UsersSummaryDto>>
    {
        private readonly IQueryUserSummaryMaterializedViewRepository _repository;

        public GetAllUsersSummaryMaterializedViewHandler(IQueryUserSummaryMaterializedViewRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<UsersSummaryDto>> Handle(GetAllUsersSummaryQueryMaterializedView request, CancellationToken cancellationToken)
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
