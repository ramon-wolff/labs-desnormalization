using EFCore.BulkExtensions;
using Labs.Cache.API.Data;
using Labs.Cache.API.Domain.Roles;
using Labs.Cache.API.Domain.Tenants;
using Labs.Cache.API.Domain.Users;

namespace Labs.Cache.API.Infra
{
    public static class DatabaseInsertion
    {
        public static void PopulateDatabase(this WebApplication application)
        {
            using var scope = application.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();

            // Se a base já estiver populada não insere nada
            var thereIsUser = db.Users.FirstOrDefault() != null;

            if(thereIsUser)
                return;

            // Inserir Tenant
            var tenantId = Guid.NewGuid();
            db.Tenants.Add(new Tenant() { Id = tenantId, Name = "globo" });

            // Inserir Perfil
            var roleId = Guid.NewGuid();
            db.Roles.Add(new Role() { Id = roleId, Name = "Diretor" });

            db.SaveChanges();

            // Inserir Usuários
            var users = new List<User>();

            for (int i = 0; i < 300000; i++)
            {
                users.Add(new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Teste",
                    Email = "teste@teste.com.br",
                    TenantId = tenantId,
                    RoleId = roleId
                });
            }

            db.BulkInsert(users);
        }
    }
}
