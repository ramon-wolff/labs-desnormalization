using MediatR;

namespace Labs.Cache.API.Application.Roles.Commands.Delete
{
    public class DeleteRoleCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
