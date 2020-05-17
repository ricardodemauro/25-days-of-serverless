using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TwitterDiscord
{
    public class FunctionTwitterDiscord
    {
        private readonly ILogger<FunctionTwitterDiscord> _logger;

        public FunctionTwitterDiscord(ILogger<FunctionTwitterDiscord> logger)
        {
            _logger = logger;
        }

        static string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("RedisConnectionString");
        }

        [FunctionName("FunctionTwitterDiscord")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            Console.WriteLine("Murta !!!!!!!!!!!!!!!");

            string text = req.Query["text"];
            string username = req.Query["username"];

            Console.WriteLine($"Text send {text} with username {username}");

            return new OkObjectResult(text);
        }
    }
}
