using Labs.Cache.API.Application.Users.Dtos;
using Labs.Cache.API.Domain.Users;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.List
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        public readonly IQueryUserRepository _repository;

        public GetAllUsersHandler(IQueryUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAll();

            return users.Select(x => new UserDto(x.Id, x.Name, x.Email, x.TenantId, x.RoleId)).ToList();
        }
    }
}
