using Labs.Cache.API.Application.Roles.Dtos;
using Labs.Cache.API.Domain.Roles;
using MediatR;

namespace Labs.Cache.API.Application.Roles.Queries.Get
{
    public class GetRoleHandler : IRequestHandler<GetRoleQuery, RoleDto>
    {
        public readonly IQueryRoleRepository _repository;

        public GetRoleHandler(IQueryRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<RoleDto> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetById(request.Id);

            if (role == null)
                return null!;

            return new RoleDto(role.Id, role.Name);
        }
    }
}
