namespace Labs.Cache.API.Domain.Tenants
{
    public interface IQueryTenantRepository
    {
        Task<List<Tenant>> GetAll();

        Task<Tenant> GetById(Guid id);
    }
}
