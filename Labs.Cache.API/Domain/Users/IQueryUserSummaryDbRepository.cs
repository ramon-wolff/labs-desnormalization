namespace Labs.Cache.API.Domain.Users
{
    public interface IQueryUserSummaryDbRepository: IQueryUserSummaryRepository
    {
        Task<List<DesnormalizedUser>> GetAllDesnormalizedUsers();

        Task<DesnormalizedUser> GetById(Guid id);
    }
}
