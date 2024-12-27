using Labs.Cache.API.Domain.Roles;
using Labs.Cache.API.Domain.Tenants;

namespace Labs.Cache.API.Domain.Users
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
