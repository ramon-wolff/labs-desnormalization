using Labs.Cache.API.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Labs.Cache.API.Data.Repository.Users
{
    public class QueryUserRepository : IQueryUserRepository
    {
        private readonly DataContext _context;

        public QueryUserRepository(DataContext context)
        {
            _context = context;
        }

        async Task<List<User>> IQueryUserRepository.GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        async Task<User> IQueryUserRepository.GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
