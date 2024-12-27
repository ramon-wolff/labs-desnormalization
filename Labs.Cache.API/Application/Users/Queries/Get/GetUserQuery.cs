using Labs.Cache.API.Application.Users.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.Get
{
    public class GetUserQuery: IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}
