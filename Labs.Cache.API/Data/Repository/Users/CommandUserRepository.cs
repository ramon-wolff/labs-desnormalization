using Labs.Cache.API.Domain.Users;

namespace Labs.Cache.API.Data.Repository.Users
{
    public class CommandUserRepository : ICommandUserRepository
    {
        private readonly DataContext _context;

        public CommandUserRepository(DataContext context)
        {
            _context = context;
        }

        void ICommandUserRepository.Create(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        void ICommandUserRepository.Delete(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        void ICommandUserRepository.Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
