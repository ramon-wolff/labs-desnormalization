using System.ComponentModel.DataAnnotations;

namespace Labs.Messaging.Consumer.Sync.Domain.Entities
{
    public class DesnormalizedUser
    {
        [Key]
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string TenantName { get; set; }

        public string RoleName { get; set; }
    }
}
