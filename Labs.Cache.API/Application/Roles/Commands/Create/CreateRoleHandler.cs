using Labs.Cache.API.Domain.Roles;
using MediatR;

namespace Labs.Cache.API.Application.Roles.Commands.Create
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand>
    {
        private readonly ICommandRoleRepository _repository;
        
        public CreateRoleHandler(ICommandRoleRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role()
            {
                Id = request.Id,
                Name = request.Name
            };

            _repository.Create(role);

            return Task.CompletedTask;
        }
    }
}
