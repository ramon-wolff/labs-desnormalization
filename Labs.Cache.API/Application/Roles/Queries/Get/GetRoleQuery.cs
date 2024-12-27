using Labs.Cache.API.Application.Roles.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Roles.Queries.Get
{
    public class GetRoleQuery : IRequest<RoleDto>
    {
        public Guid Id { get; set; }
    }
}
