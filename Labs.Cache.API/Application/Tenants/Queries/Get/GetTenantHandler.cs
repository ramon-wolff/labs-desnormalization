using Labs.Cache.API.Application.Tenants.Dtos;
using Labs.Cache.API.Domain.Tenants;
using MediatR;

namespace Labs.Cache.API.Application.Tenants.Queries.Get
{
    public class GetTenantHandler : IRequestHandler<GetTenantQuery, TenantDto>
    {
        public readonly IQueryTenantRepository _repository;

        public GetTenantHandler(IQueryTenantRepository repository)
        {
            _repository = repository;
        }

        public async Task<TenantDto> Handle(GetTenantQuery request, CancellationToken cancellationToken)
        {
            var tenant = await _repository.GetById(request.Id);

            if (tenant == null)
                return null!;

            return new TenantDto(tenant.Id, tenant.Name);
        }
    }
}
