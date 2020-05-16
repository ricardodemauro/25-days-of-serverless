using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Imache
{
    public class FunctionSearchPhotos
    {
        private readonly ILogger<FunctionSearchPhotos> _logger;

        private readonly UnsplashService _service;

        public FunctionSearchPhotos(ILogger<FunctionSearchPhotos> logger,
                                UnsplashService service)
        {
            _logger = logger;
            _service = service;
        }

        static string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("RedisConnectionString");
        }

        [FunctionName("FunctionSearchPhotos")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string searchString = req.Query["searchString"];
            string color = req.Query["color"].ToString() ?? "red";

            var result = await _service.SearchPhotos(searchString, color);

            return new OkObjectResult(result);
        }
    }
}
