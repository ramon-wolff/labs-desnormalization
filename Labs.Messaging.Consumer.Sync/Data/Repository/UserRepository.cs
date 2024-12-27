using EFCore.BulkExtensions;
using Labs.Messaging.Consumer.Sync.Domain.Entities;
using Labs.Messaging.Consumer.Sync.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labs.Messaging.Consumer.Sync.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteUsers()
        {
            await _context.DesnormalizedUsers.ExecuteDeleteAsync();
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users
                                .Include(t => t.Tenant)
                                .Include(r => r.Role)
                                .ToListAsync();

            return users;
        }

        public async Task AddDesnormalizedUsers(List<DesnormalizedUser> desnormalizedUsers)
        {
            await _context.BulkInsertAsync(desnormalizedUsers);
            _context.SaveChanges();
        }
    }
}
