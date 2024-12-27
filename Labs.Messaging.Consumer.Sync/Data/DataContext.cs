using Labs.Messaging.Consumer.Sync.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Labs.Messaging.Consumer.Sync.Data
{
    public class DataContext: DbContext
    {
        public DbSet<DesnormalizedUser> DesnormalizedUsers { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DataDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<DesnormalizedUser>()
                .ToTable(nameof(DesnormalizedUser))
                .HasIndex(u => u.UserId);
        }
    }
}
