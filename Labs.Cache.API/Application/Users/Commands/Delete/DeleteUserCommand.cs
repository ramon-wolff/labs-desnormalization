using MediatR;

namespace Labs.Cache.API.Application.Users.Commands.Delete
{
    public class DeleteUserCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}
