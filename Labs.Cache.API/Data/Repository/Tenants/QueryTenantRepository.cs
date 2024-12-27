using Labs.Cache.API.Domain.Tenants;
using Microsoft.EntityFrameworkCore;

namespace Labs.Cache.API.Data.Repository.Tenants
{
    public class QueryTenantRepository : IQueryTenantRepository
    {
        private readonly DataContext _context;

        public QueryTenantRepository(DataContext context)
        {
            _context = context;
        }

        async Task<List<Tenant>> IQueryTenantRepository.GetAll()
        {
            return await _context.Tenants.ToListAsync();
        }

        async Task<Tenant> IQueryTenantRepository.GetById(Guid id)
        {
            return await _context.Tenants.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
