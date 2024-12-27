using Labs.Cache.API.Application.Services.Messaging;
using Labs.Cache.API.Application.Services.MongoDb;
using Labs.Cache.API.Application.Services.Redis;
using Labs.Cache.API.Data;
using Labs.Cache.API.Data.Repository.Roles;
using Labs.Cache.API.Data.Repository.Tenants;
using Labs.Cache.API.Data.Repository.Users;
using Labs.Cache.API.Data.Repository.Users.Db;
using Labs.Cache.API.Data.Repository.Users.MaterializedView;
using Labs.Cache.API.Data.Repository.Users.MongoDb;
using Labs.Cache.API.Domain.Roles;
using Labs.Cache.API.Domain.Tenants;
using Labs.Cache.API.Domain.Users;
using Labs.Cache.API.Extensions;
using Labs.Cache.API.Infra;
using MassTransit;
using MongoDB.Driver;
using MongoDB.Driver.Core.Extensions.DiagnosticSources;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using StackExchange.Redis;
using System.Reflection;
using System.Security.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>();

// Command repositories
builder.Services.AddScoped<ICommandRoleRepository, CommandRoleRepository>();
builder.Services.AddScoped<ICommandTenantRepository, CommandTenantRepository>();
builder.Services.AddScoped<ICommandUserRepository, CommandUserRepository>();

// Query repositories
builder.Services.AddScoped<IQueryRoleRepository, QueryRoleRepository>();
builder.Services.AddScoped<IQueryTenantRepository, QueryTenantRepository>();
builder.Services.AddScoped<IQueryUserRepository, QueryUserRepository>();
builder.Services.AddScoped<IQueryUserSummaryDbRepository, QueryUserSummaryDbRepository>();
builder.Services.AddScoped<IQueryUserSummaryMongoDbRepository, QueryUserSummaryMongoDbRepository>();
builder.Services.AddScoped<IQueryUserSummaryMaterializedViewRepository, QueryUserSummaryMaterializedViewRepository>();

// Services
builder.Services.AddScoped<IRedisService, RedisService>();
builder.Services.AddScoped<IMongoDbService, MongoDbService>();
builder.Services.AddScoped<IMessagingService, MessagingService>();

builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Add Redis configuration
var connection = ConnectionMultiplexer.Connect(RedisConsts.RedisUri);
builder.Services.AddSingleton<IConnectionMultiplexer>(options => connection);

// Register MongoDB client
var settings = MongoClientSettings.FromUrl(new MongoUrl(MongoDbConsts.ConnectionString));
settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

// Register MongoDB telemetry
var options = new InstrumentationOptions { CaptureCommandText = true };
settings.ClusterConfigurator = cb => { cb.Subscribe(new DiagnosticsActivityEventSubscriber(options)); };

builder.Services.AddSingleton<IMongoClient>(new MongoClient(settings));

// Register Masstransit and RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) => Bus.Factory.CreateUsingRabbitMq(config =>
    {
        config.Host(new Uri(RabbitMqConsts.RabbitMqRootUri), h =>
        {
            h.Username(RabbitMqConsts.Username);
            h.Password(RabbitMqConsts.Password);
        });
    }));
});

builder.Services.AddOpenTelemetry()
  .ConfigureResource(resource => resource.AddService(OpenTelemetryConsts.ServiceName))
  .WithTracing(builder =>
  {
      builder
          .AddAspNetCoreInstrumentation()
          .AddHttpClientInstrumentation()
          .AddEntityFrameworkCoreInstrumentation(x => x.SetDbStatementForText = true)
          .AddSqlClientInstrumentation(options => options.SetDbStatementForText = true)
          .AddRedisInstrumentation(connection, opt => opt.FlushInterval = TimeSpan.FromSeconds(1))
          .AddSource(OpenTelemetryConsts.MongoDBSource)
          .AddOtlpExporter(opts =>
          {
              opts.Endpoint = new Uri(OpenTelemetryConsts.JaegerEndpoint);
          });
  });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt => // UseSwaggerUI is called only in Development.
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        opt.RoutePrefix = string.Empty;
    });
}

app.MigrateDb();
app.PopulateDatabase();

app.Run();
