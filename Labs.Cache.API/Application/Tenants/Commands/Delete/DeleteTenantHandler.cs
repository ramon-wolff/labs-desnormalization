using Labs.Cache.API.Domain.Tenants;
using MediatR;

namespace Labs.Cache.API.Application.Tenants.Commands.Delete
{
    public class DeleteTenantHandler : IRequestHandler<DeleteTenantCommand>
    {
        private readonly ICommandTenantRepository _commandTenantRepository;
        private readonly IQueryTenantRepository _queryTenantRepository;

        public DeleteTenantHandler(ICommandTenantRepository commandTenantRepository, IQueryTenantRepository queryTenantRepository)
        {
            _commandTenantRepository = commandTenantRepository;
            _queryTenantRepository = queryTenantRepository;
        }

        public Task Handle(DeleteTenantCommand request, CancellationToken cancellationToken)
        {
            var role = _queryTenantRepository.GetById(request.Id);

            if (role.Result == null)
                return Task.CompletedTask;

            _commandTenantRepository.Delete(role.Result);

            return Task.CompletedTask;
        }
    }
}
