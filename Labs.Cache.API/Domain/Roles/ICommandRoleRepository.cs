namespace Labs.Cache.API.Domain.Roles
{
    public interface ICommandRoleRepository
    {
        void Create(Role role);

        void Update(Role role);

        void Delete(Role role);
    }
}
