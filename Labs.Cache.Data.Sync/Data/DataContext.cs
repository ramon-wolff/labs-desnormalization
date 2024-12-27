using Labs.Cache.Data.Sync.Domain.Roles;
using Labs.Cache.Data.Sync.Domain.Tenants;
using Labs.Cache.Data.Sync.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Labs.Cache.Data.Sync.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DataDb;Trusted_Connection=True;");
        }
    }
}
