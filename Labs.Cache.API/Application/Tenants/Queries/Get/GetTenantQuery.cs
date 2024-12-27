using Labs.Cache.API.Application.Tenants.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Tenants.Queries.Get
{
    public class GetTenantQuery : IRequest<TenantDto>
    {
        public Guid Id { get; set; }
    }
}
