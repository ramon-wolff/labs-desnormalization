namespace Labs.Cache.API.Application.Roles.Dtos
{
    public class RoleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public RoleDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
