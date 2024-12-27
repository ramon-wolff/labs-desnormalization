using MediatR;

namespace Labs.Cache.API.Application.Tenants.Commands.Update
{
    public class UpdateTenantCommand : IRequest
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}
