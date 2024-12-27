using MediatR;

namespace Labs.Cache.API.Application.Tenants.Commands.Create
{
    public class CreateTenantCommand: IRequest
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}
