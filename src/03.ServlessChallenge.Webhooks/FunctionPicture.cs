using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization.Conventions;
using ServlessChallenge.Webhooks.Models;
using System;
using System.Threading.Tasks;

namespace ServlessChallenge.Webhooks
{
    public class FunctionPicture
    {
        private readonly PictureService _service;
        private readonly ILogger<FunctionPicture> _logger;

        public FunctionPicture(PictureService service, ILogger<FunctionPicture> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [FunctionName("FunctionAddPicture")]
        public async Task<IActionResult> AddPicture(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var pic = new Picture()
            {
                Created = DateTime.UtcNow,
                CreatedBy = "System",
                Name = name
            };
            var dbPic = await _service.Create(pic);

            return new JsonResult(dbPic);
        }
    }
}
