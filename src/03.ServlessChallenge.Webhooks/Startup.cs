using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ServlessChallenge.Webhooks.MongoDb;
using System;

[assembly: FunctionsStartup(typeof(ServlessChallenge.Webhooks.Startup))]

namespace ServlessChallenge.Webhooks
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string collection = Environment.GetEnvironmentVariable("MongoCollectionName");
            string database = Environment.GetEnvironmentVariable("MongoDatabaseName");
            string connectionString = Environment.GetEnvironmentVariable("MongoConnectionString");

            builder.Services.AddOptions();
            builder.Services.Configure<MongoDbOptions>(opts =>
            {
                opts.ConnectionString = connectionString;
                opts.DatabaseName = database;
                opts.Collection = collection;
            });
            builder.Services.AddSingleton(x => x.GetRequiredService<IOptions<MongoDbOptions>>().Value);

            builder.Services.AddTransient<PictureService>();
        }
    }
}
