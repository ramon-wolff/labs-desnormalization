using Labs.Cache.API.Domain.Roles;
using Microsoft.EntityFrameworkCore;

namespace Labs.Cache.API.Data.Repository.Roles
{
    public class QueryRoleRepository : IQueryRoleRepository
    {
        private readonly DataContext _context;

        public QueryRoleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetById(Guid id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
