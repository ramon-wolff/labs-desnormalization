namespace Labs.Cache.Data.Sync.Domain.Users
{
    public interface ISynchronizeUserSummaryService
    {
        Task SynchronizeUserSummary(CancellationToken stoppingToken);
    }
}
