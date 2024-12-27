using MediatR;

namespace Labs.Cache.API.Application.Roles.Commands.Create
{
    public class CreateRoleCommand : IRequest
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}
