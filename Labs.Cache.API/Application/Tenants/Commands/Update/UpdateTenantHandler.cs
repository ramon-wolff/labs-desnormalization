using Labs.Cache.API.Domain.Tenants;
using MediatR;

namespace Labs.Cache.API.Application.Tenants.Commands.Update
{
    public class UpdateTenantHandler : IRequestHandler<UpdateTenantCommand>
    {
        private readonly ICommandTenantRepository _repository;

        public UpdateTenantHandler(ICommandTenantRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = new Tenant()
            {
                Id = request.Id,
                Name = request.Name
            };

            _repository.Update(tenant);

            return Task.CompletedTask;
        }
    }
}
