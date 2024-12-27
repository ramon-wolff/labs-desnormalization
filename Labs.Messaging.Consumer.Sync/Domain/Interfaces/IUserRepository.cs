using Labs.Messaging.Consumer.Sync.Domain.Entities;

namespace Labs.Messaging.Consumer.Sync.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task DeleteUsers();

        Task<List<User>> GetAll();

        Task AddDesnormalizedUsers(List<DesnormalizedUser> desnormalizedUsers);
    }
}
