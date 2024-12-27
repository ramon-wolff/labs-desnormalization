using MediatR;

namespace Labs.Cache.API.Application.Users.Commands.Update
{
    public class UpdateUserCommand: IRequest
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public Guid TenantId { get; set; }

        public Guid RoleId { get; set; }
    }
}
