namespace Labs.Cache.Data.Sync.Domain.Tenants
{
    public class Tenant
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}
