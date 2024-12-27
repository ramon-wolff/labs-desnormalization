namespace Labs.Cache.API.Domain.Users
{
    public interface IQueryUserSummaryMongoDbRepository: IQueryUserSummaryRepository
    {
        Task<UserSummary> GetById(Guid id);
    }
}
