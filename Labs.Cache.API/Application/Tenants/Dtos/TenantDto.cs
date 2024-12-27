namespace Labs.Cache.API.Application.Tenants.Dtos
{
    public class TenantDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TenantDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
