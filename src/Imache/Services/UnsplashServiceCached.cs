using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imache.Services
{
    public class UnsplashServiceCached : UnsplashService
    {
        private readonly IDistributedCache _distributedCache;

        public UnsplashServiceCached(ILogger<UnsplashService> logger,
            UnsplashServiceOptions options,
            IDistributedCache distributedCache)
            : base(logger, options)
        {
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }

        public override Task<IEnumerable<string>> SearchPhotos(string searchString, string color)
        {
            return GetFromCache(searchString, color, base.SearchPhotos);
        }

        public async Task<IEnumerable<string>> GetFromCache(string searchString,
            string color,
            Func<string, string, Task<IEnumerable<string>>> realService)
        {
            string rawPictures = await _distributedCache.GetStringAsync($"{searchString}-{color}");

            if (string.IsNullOrEmpty(rawPictures))
            {
                var pictures = await realService(searchString, color);
                rawPictures = JsonConvert.SerializeObject(pictures);

                await _distributedCache.SetStringAsync($"{searchString}-{color}", rawPictures, new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromSeconds(10)
                });

                return pictures;
            }

            return JsonConvert.DeserializeObject<string[]>(rawPictures);
        }
    }
}
