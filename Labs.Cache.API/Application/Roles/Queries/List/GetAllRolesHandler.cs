using Labs.Cache.API.Application.Roles.Dtos;
using Labs.Cache.API.Domain.Roles;
using MediatR;

namespace Labs.Cache.API.Application.Roles.Queries.List
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, List<RoleDto>>
    {
        public readonly IQueryRoleRepository _repository;

        public GetAllRolesHandler(IQueryRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _repository.GetAll();

            return roles.Select(x => new RoleDto(x.Id, x.Name)).ToList();
        }
    }
}
