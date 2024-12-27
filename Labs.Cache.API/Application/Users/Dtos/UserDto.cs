namespace Labs.Cache.API.Application.Users.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Guid TenantId { get; set; }

        public Guid RoleId { get; set; }

        public UserDto(Guid id, string name, string email, Guid tenantId, Guid roleId)
        {
            Id = id;
            Name = name;
            Email = email;
            TenantId = tenantId;
            RoleId = roleId;
        }
    }
}
