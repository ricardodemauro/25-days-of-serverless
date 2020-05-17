using System;
using Imache.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

[assembly: FunctionsStartup(typeof(Imache.Startup))]

namespace Imache
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();

            builder.Services.AddOptions();

            builder.Services.AddUnsplashOptions();

            builder.Services.AddTransient<UnsplashService, UnsplashServiceCached>();

            builder.Services.AddDistributedRedisCache(opts =>
            {
                opts.Configuration = Environment.GetEnvironmentVariable("RedisConnectionString");
                opts.InstanceName = "ServelessChallenge";
            });
        }
    }
}