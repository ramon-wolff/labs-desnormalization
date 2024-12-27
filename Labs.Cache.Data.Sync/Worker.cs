using Labs.Cache.Data.Sync.Domain.Users;

namespace Labs.Cache.Data.Sync
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly ISynchronizeUserSummaryService _synchronizeUserSummaryService;

        private readonly IServiceScopeFactory _service;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _service = scopeFactory;

            using var scope = _service.CreateScope();
            _synchronizeUserSummaryService = scope.ServiceProvider.GetRequiredService<ISynchronizeUserSummaryService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await _synchronizeUserSummaryService.SynchronizeUserSummary(stoppingToken);

                await Task.Delay(60000, stoppingToken); // Vai rodar a sincronia a cada 1 min
            }
        }
    }
}
