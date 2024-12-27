using Labs.Cache.API.Application.Users.Dtos;
using Labs.Cache.API.Domain.Users;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.Get
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        public readonly IQueryUserRepository _repository;

        public GetUserHandler(IQueryUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);

            if (user == null)
                return null!;

            return new UserDto(user.Id, user.Name, user.Email, user.TenantId, user.RoleId);
        }
    }
}
