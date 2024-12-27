using Labs.Cache.API.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Labs.Cache.API.Data.Repository.Users.MaterializedView
{
    public class QueryUserSummaryMaterializedViewRepository : IQueryUserSummaryMaterializedViewRepository
    {
        private readonly DataContext _context;

        public QueryUserSummaryMaterializedViewRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserSummary>> GetAll()
        {
            return await _context.UserSummary.ToListAsync();
        }

        public async Task<UserSummary> GetById(Guid id)
        {
            return await _context.UserSummary.FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}