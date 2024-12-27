using Labs.Cache.API.Application.Tenants.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Tenants.Queries.List
{
    public class GetAllTenantsQuery : IRequest<List<TenantDto>>
    {
    }
}
