using Labs.Cache.API.Application.Users.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.List
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
    }
}
