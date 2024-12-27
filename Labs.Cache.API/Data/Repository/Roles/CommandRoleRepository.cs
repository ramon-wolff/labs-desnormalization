using Labs.Cache.API.Domain.Roles;

namespace Labs.Cache.API.Data.Repository.Roles
{
    public class CommandRoleRepository : ICommandRoleRepository
    {
        private readonly DataContext _context;

        public CommandRoleRepository(DataContext context)
        {
            _context = context;
        }

        void ICommandRoleRepository.Create(Role role)
        {
            _context.Add(role);
            _context.SaveChanges();
        }

        void ICommandRoleRepository.Delete(Role role)
        {
            _context.Remove(role);
            _context.SaveChanges();
        }

        void ICommandRoleRepository.Update(Role role)
        {
            _context.Update(role);
            _context.SaveChanges();
        }
    }
}
