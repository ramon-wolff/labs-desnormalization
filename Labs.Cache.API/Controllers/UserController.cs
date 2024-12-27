using Labs.Cache.API.Application.Users.Commands.Create;
using Labs.Cache.API.Application.Users.Commands.Delete;
using Labs.Cache.API.Application.Users.Commands.Update;
using Labs.Cache.API.Application.Users.Dtos;
using Labs.Cache.API.Application.Users.Queries.Get;
using Labs.Cache.API.Application.Users.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Cache.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetAllUsers()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet("user")]
        public async Task<UserDto> GetUser(Guid userId)
        {
            return await _mediator.Send(new GetUserQuery() { Id = userId });
        }

        [HttpPost]
        public async Task CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task UpdateUser(UpdateUserCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task DeleteUser(DeleteUserCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
