namespace Labs.Cache.API.Domain.Users
{
    public interface IQueryUserRepository
    {
        Task<List<User>> GetAll();

        Task<User> GetById(Guid id);
    }
}
