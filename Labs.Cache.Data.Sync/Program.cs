using Labs.Cache.Data.Sync;
using Labs.Cache.Data.Sync.Data;
using Labs.Cache.Data.Sync.Domain.Users;
using Labs.Cache.Data.Sync.Services;
using MongoDB.Driver;
using System.Security.Authentication;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddDbContext<DataContext>();

// Register MongoDB client
var connectionString = builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString");
var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

builder.Services.AddSingleton<IMongoClient>(new MongoClient(settings));
builder.Services.AddScoped<ISynchronizeUserSummaryService, SynchronizeUserSummaryService>();

var host = builder.Build();

// Aguardar o banco que a API cria
await Task.Delay(30000); 
host.Run();
