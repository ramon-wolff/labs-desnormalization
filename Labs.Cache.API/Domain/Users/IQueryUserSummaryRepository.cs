namespace Labs.Cache.API.Domain.Users
{
    public interface IQueryUserSummaryRepository
    {
        Task<List<UserSummary>> GetAll();
    }
}
