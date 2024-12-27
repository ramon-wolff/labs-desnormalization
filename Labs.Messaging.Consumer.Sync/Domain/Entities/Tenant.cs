namespace Labs.Messaging.Consumer.Sync.Domain.Entities
{
    public class Tenant
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}
