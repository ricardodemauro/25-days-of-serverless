using Imache.Services;
using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace Imache
{
    public class UnsplashService
    {
        const int ItemsPerPage = 3;

        private readonly string _apiKey;

        private readonly ILogger<UnsplashService> _logger;

        private readonly string _baseUri;

        public UnsplashService(ILogger<UnsplashService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _apiKey = Environment.GetEnvironmentVariable("UnsplashKey");
            _baseUri = Environment.GetEnvironmentVariable("UnsplashApiUri");
        }

        public async Task<IEnumerable<string>> SearchPhotos(string searchString, string color)
        {
            _logger.LogInformation("BaseUri {baseuri}", _baseUri);
            _logger.LogInformation("searchString {searchString}", searchString);
            _logger.LogInformation("color {color}", color);
            _logger.LogInformation("ItemsPerPage {ItemsPerPage}", ItemsPerPage);
            _logger.LogInformation("_apiKey {_apiKey}", _apiKey);

            var api = RestService.For<IUnsplashService>(_baseUri);

            var searchResult = await api.SearchPhotos(searchString, color, ItemsPerPage, _apiKey);

            return searchResult.results.Select(x => x.urls.regular);
        }
    }
}
