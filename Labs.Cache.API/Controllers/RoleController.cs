using Labs.Cache.API.Application.Roles.Commands.Create;
using Labs.Cache.API.Application.Roles.Commands.Delete;
using Labs.Cache.API.Application.Roles.Commands.Update;
using Labs.Cache.API.Application.Roles.Dtos;
using Labs.Cache.API.Application.Roles.Queries.Get;
using Labs.Cache.API.Application.Roles.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Cache.API.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<RoleDto>> GetAllRoles()
        {
            return await _mediator.Send(new GetAllRolesQuery());
        }

        [HttpGet("role")]
        public async Task<RoleDto> GetRole(Guid roleId)
        {
            return await _mediator.Send(new GetRoleQuery() { Id = roleId });
        }

        [HttpPost]
        public async Task CreateRole(CreateRoleCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task UpdateRole(UpdateRoleCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task DeleteRole(DeleteRoleCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
