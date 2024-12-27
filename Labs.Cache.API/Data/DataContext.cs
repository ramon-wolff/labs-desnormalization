using Labs.Cache.API.Domain.Roles;
using Labs.Cache.API.Domain.Tenants;
using Labs.Cache.API.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Labs.Cache.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserSummary> UserSummary { get; set; }

        public DbSet<DesnormalizedUser> DesnormalizedUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DataDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserSummary>()
                .ToView(nameof(UserSummary))
                .HasNoKey()
                .HasIndex(u => u.UserId);

            modelBuilder
                .Entity<DesnormalizedUser>()
                .ToTable(nameof(DesnormalizedUser))
                .HasIndex(u => u.UserId);
        }
    }
}
