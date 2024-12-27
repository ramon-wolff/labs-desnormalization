using Labs.Messaging.Consumer.Sync.Application;
using Labs.Messaging.Consumer.Sync.Data;
using Labs.Messaging.Consumer.Sync.Data.Repository;
using Labs.Messaging.Consumer.Sync.Domain.Interfaces;
using Labs.Messaging.Consumer.Sync.Extensions;
using Labs.Messaging.Consumer.Sync.Infra;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register Masstransit and RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<UserDataUpdatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri(RabbitMqConsts.RabbitMqRootUri), h =>
        {
            h.Username(RabbitMqConsts.Username);
            h.Password(RabbitMqConsts.Password);
        });
        cfg.UseMessageRetry(r => r.Immediate(5));
        cfg.ReceiveEndpoint(RabbitMqConsts.ReceiveEndpoint, e =>
        {
            e.ConfigureConsumer<UserDataUpdatedConsumer>(context);
        });
    });
});

using IHost host = builder.Build();

host.MigrateDb();

host.Run();