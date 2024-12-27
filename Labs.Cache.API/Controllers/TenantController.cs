using Labs.Cache.API.Application.Tenants.Commands.Create;
using Labs.Cache.API.Application.Tenants.Commands.Delete;
using Labs.Cache.API.Application.Tenants.Commands.Update;
using Labs.Cache.API.Application.Tenants.Dtos;
using Labs.Cache.API.Application.Tenants.Queries.Get;
using Labs.Cache.API.Application.Tenants.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Cache.API.Controllers
{
    [ApiController]
    [Route("api/tenants")]
    public class TenantController: ControllerBase
    {
        private readonly IMediator _mediator;

        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<TenantDto>> GetAllTenants()
        {
            return await _mediator.Send(new GetAllTenantsQuery());
        }

        [HttpGet("tenant")]
        public async Task<TenantDto> GetTenant(Guid tenantId)
        {
            return await _mediator.Send(new GetTenantQuery() { Id = tenantId });
        }

        [HttpPost]
        public async Task CreateTenant(CreateTenantCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task UpdateTenant(UpdateTenantCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task DeleteTenant(DeleteTenantCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
