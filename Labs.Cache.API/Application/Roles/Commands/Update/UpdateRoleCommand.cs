using MediatR;

namespace Labs.Cache.API.Application.Roles.Commands.Update
{
    public class UpdateRoleCommand : IRequest
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}
