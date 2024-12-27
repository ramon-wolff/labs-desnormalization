namespace Labs.Cache.API.Domain.Users
{
    public interface IQueryUserSummaryMaterializedViewRepository : IQueryUserSummaryRepository
    {
        Task<UserSummary> GetById(Guid id);
    }
}
