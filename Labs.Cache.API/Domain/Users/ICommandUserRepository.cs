namespace Labs.Cache.API.Domain.Users
{
    public interface ICommandUserRepository
    {
        void Create(User user);

        void Update(User user);

        void Delete(User user);
    }
}
