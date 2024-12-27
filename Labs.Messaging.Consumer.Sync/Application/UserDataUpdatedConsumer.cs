using Labs.Messaging.Consumer.Sync.Domain.Entities;
using Labs.Messaging.Consumer.Sync.Domain.Interfaces;
using Labs.Messaging.Events;
using MassTransit;

namespace Labs.Messaging.Consumer.Sync.Application
{
    public class UserDataUpdatedConsumer : IConsumer<UserDataUpdatedEvent>
    {
        private readonly IUserRepository _userRepository;

        public UserDataUpdatedConsumer(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Consume(ConsumeContext<UserDataUpdatedEvent> context)
        {
            // Remove os dados da tabela desnormalizada
            await _userRepository.DeleteUsers();

            // Seleciona novamente os dados atualizados
            var users = await _userRepository.GetAll();

            var desnormalizedUsers = Task.FromResult(users.Select(x => new DesnormalizedUser()
            {
                UserId = x.Id,
                Name = x.Name,
                Email = x.Email,
                TenantName = x.Tenant.Name,
                RoleName = x.Role.Name
            })).Result.ToList();

            // Insere os dados novos para consultas
            await _userRepository.AddDesnormalizedUsers(desnormalizedUsers);
        }
    }
}
