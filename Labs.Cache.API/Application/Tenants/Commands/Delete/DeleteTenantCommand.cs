using MediatR;

namespace Labs.Cache.API.Application.Tenants.Commands.Delete
{
    public class DeleteTenantCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}
