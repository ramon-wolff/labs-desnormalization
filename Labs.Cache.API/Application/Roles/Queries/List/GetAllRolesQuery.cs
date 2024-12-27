using Labs.Cache.API.Application.Roles.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Roles.Queries.List
{
    public class GetAllRolesQuery : IRequest<List<RoleDto>>
    {

    }
}
