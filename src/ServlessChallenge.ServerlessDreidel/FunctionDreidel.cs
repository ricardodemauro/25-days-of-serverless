using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ServlessChallenge.ServerlessDreidel
{
    public static class FunctionDreidel
    {
        static readonly string[] _values = new string[] { "נ", "ג", "ה", "ש" };

        static readonly Random _random = new Random();

        [FunctionName("FunctionDreidel")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            int randomIndex = _random.Next(0, _values.Length - 1);

            return new OkObjectResult($"Dreidel --> {_values[randomIndex]}");
        }
    }
}
