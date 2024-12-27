using Labs.Cache.API.Domain.Roles;
using MediatR;

namespace Labs.Cache.API.Application.Roles.Commands.Delete
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly ICommandRoleRepository _commandRoleRepository;
        private readonly IQueryRoleRepository _queryRoleRepository;

        public DeleteRoleHandler(ICommandRoleRepository commandRoleRepository, IQueryRoleRepository queryRoleRepository)
        {
            _commandRoleRepository = commandRoleRepository;
            _queryRoleRepository = queryRoleRepository;
        }

        public Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _queryRoleRepository.GetById(request.Id);

            if (role.Result == null)
                return Task.CompletedTask;

            _commandRoleRepository.Delete(role.Result);

            return Task.CompletedTask;
        }
    }
}
