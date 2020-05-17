using Imache.Services;
using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Imache.Services.Api;

namespace Imache.Services
{
    public class UnsplashService
    {
        const int ItemsPerPage = 3;

        private readonly ILogger<UnsplashService> _logger;

        private readonly UnsplashServiceOptions _options;


        public UnsplashService(ILogger<UnsplashService> logger, UnsplashServiceOptions options)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public virtual async Task<IEnumerable<string>> SearchPhotos(string searchString, string color)
        {
            _logger.LogInformation("SearchString {searchString} Color {color}", searchString, color);

            var api = RestService.For<IUnsplashService>(_options.UnsplashApiUri);

            var searchResult = await api.SearchPhotos(searchString, color, ItemsPerPage, _options.UnsplashKey);

            return searchResult.results.Select(x => x.urls.regular);
        }
    }
}
