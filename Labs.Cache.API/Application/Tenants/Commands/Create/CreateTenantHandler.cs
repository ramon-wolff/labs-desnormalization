using Labs.Cache.API.Domain.Tenants;
using MediatR;

namespace Labs.Cache.API.Application.Tenants.Commands.Create
{
    public class CreateTenantHandler : IRequestHandler<CreateTenantCommand>
    {
        private readonly ICommandTenantRepository _repository;

        public CreateTenantHandler(ICommandTenantRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = new Tenant()
            {
                Id = request.Id,
                Name = request.Name
            };

            _repository.Create(tenant);

            return Task.CompletedTask;
        }
    }
}
