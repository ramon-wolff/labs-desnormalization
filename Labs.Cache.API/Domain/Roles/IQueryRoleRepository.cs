namespace Labs.Cache.API.Domain.Roles
{
    public interface IQueryRoleRepository
    {
        Task<List<Role>> GetAll();

        Task<Role> GetById(Guid id);
    }
}
