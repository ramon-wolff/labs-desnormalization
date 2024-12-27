using Labs.Cache.API.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labs.Cache.API.Extensions
{
    public static class DatabaseExtensions
    {
        public static void MigrateDb(this WebApplication application)
        {
            using var scope = application.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();
            var migrator = db.Database.GetService<IMigrator>();
            migrator.Migrate();
        }
    }
}
