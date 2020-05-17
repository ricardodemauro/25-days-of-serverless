using Imache.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imache
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddUnsplashOptions(this IServiceCollection services)
        {
            services.Configure<UnsplashServiceOptions>(opt =>
            {
                opt.UnsplashKey = Environment.GetEnvironmentVariable("UnsplashKey");
                opt.UnsplashApiUri = Environment.GetEnvironmentVariable("UnsplashApiUri");
            });

            services.AddTransient(services => services.GetRequiredService<IOptions<UnsplashServiceOptions>>().Value);

            return services;
        }
    }
}
