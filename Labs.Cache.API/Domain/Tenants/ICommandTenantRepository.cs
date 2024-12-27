namespace Labs.Cache.API.Domain.Tenants
{
    public interface ICommandTenantRepository
    {
        void Create(Tenant tenant);

        void Update(Tenant tenant);

        void Delete(Tenant tenant);
    }
}
