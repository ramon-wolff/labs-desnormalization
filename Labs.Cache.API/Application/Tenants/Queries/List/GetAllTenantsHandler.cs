using Labs.Cache.API.Application.Tenants.Dtos;
using Labs.Cache.API.Domain.Tenants;
using MediatR;

namespace Labs.Cache.API.Application.Tenants.Queries.List
{
    public class GetAllTenantsHandler : IRequestHandler<GetAllTenantsQuery, List<TenantDto>>
    {
        public readonly IQueryTenantRepository _repository;

        public GetAllTenantsHandler(IQueryTenantRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TenantDto>> Handle(GetAllTenantsQuery request, CancellationToken cancellationToken)
        {
            var tenants = await _repository.GetAll();

            return tenants.Select(x => new TenantDto(x.Id, x.Name)).ToList();
        }
    }
}
