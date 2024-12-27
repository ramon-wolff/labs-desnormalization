using Labs.Cache.API.Domain.Tenants;

namespace Labs.Cache.API.Data.Repository.Tenants
{
    public class CommandTenantRepository : ICommandTenantRepository
    {
        private readonly DataContext _context;

        public CommandTenantRepository(DataContext context)
        {
            _context = context;
        }

        void ICommandTenantRepository.Create(Tenant tenant)
        {
            _context.Add(tenant);
            _context.SaveChanges();
        }

        void ICommandTenantRepository.Delete(Tenant tenant)
        {
            _context.Remove(tenant);
            _context.SaveChanges();
        }

        void ICommandTenantRepository.Update(Tenant tenant)
        {
            _context.Update(tenant);
            _context.SaveChanges();
        }
    }
}
