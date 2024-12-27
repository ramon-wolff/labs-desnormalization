namespace Labs.Cache.API.Application.Users.Dtos
{
    public class UsersSummaryDto
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string TenantName { get; set; }

        public string RoleName { get; set; }
    }
}
