namespace Labs.Cache.API.Domain.Tenants
{
    public class Tenant
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}
