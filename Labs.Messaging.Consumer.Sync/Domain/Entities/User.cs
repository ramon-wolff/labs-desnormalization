namespace Labs.Messaging.Consumer.Sync.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public Guid TenantId { get; set; }

        public Tenant Tenant { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }
    }
}
