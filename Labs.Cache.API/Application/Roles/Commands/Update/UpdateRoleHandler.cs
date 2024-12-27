using Labs.Cache.API.Domain.Roles;
using MediatR;

namespace Labs.Cache.API.Application.Roles.Commands.Update
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly ICommandRoleRepository _repository;

        public UpdateRoleHandler(ICommandRoleRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role()
            {
                Id = request.Id,
                Name = request.Name
            };

            _repository.Update(role);

            return Task.CompletedTask;
        }
    }
}
