using Labs.Cache.API.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Labs.Cache.API.Data.Repository.Users.Db
{
    public class QueryUserSummaryDbRepository : IQueryUserSummaryDbRepository
    {
        private readonly DataContext _context;

        public QueryUserSummaryDbRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserSummary>> GetAll()
        {
            var users = await _context.Users
                                .Include(t => t.Tenant)
                                .Include(r => r.Role)
                                .ToListAsync();

            return Task.FromResult(users.Select(x => new UserSummary()
            {
                UserId = x.Id,
                Name = x.Name,
                Email = x.Email,
                TenantName = x.Tenant.Name,
                RoleName = x.Role.Name
            })).Result.ToList();
        }

        public async Task<List<DesnormalizedUser>> GetAllDesnormalizedUsers()
        {
            return await _context.DesnormalizedUsers.ToListAsync();
        }

        public async Task<DesnormalizedUser> GetById(Guid id)
        {
            return await _context.DesnormalizedUsers.FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
