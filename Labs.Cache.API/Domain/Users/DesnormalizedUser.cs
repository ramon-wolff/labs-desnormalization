using System.ComponentModel.DataAnnotations;

namespace Labs.Cache.API.Domain.Users
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
