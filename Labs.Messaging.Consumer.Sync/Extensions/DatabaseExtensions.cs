using Labs.Messaging.Consumer.Sync.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Labs.Messaging.Consumer.Sync.Extensions
{
    public static class DatabaseExtensions
    {
        public static void MigrateDb(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();
            var migrator = db.Database.GetService<IMigrator>();
            migrator.Migrate();
        }
    }
}
