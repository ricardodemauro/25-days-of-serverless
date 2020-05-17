using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using twitterDiscord;
using Refit;
using System.Net.Http;
using System.Text;

namespace TwitterDiscord
{
    public class FunctionTwitterDiscord
    {
        private readonly ILogger<FunctionTwitterDiscord> _logger;

        public FunctionTwitterDiscord(ILogger<FunctionTwitterDiscord> logger)
        {
            _logger = logger;
        }

        static string DiscordApi => Environment.GetEnvironmentVariable("DiscordApi");

        static string DiscordBotToken => Environment.GetEnvironmentVariable("DiscordBotToken");

        static string DiscordChannelId => Environment.GetEnvironmentVariable("DiscordChannelId");

        [FunctionName("FunctionTwitterDiscord")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            Console.WriteLine("Murta !!!!!!!!!!!!!!!");

            string text = req.Query["text"];
            string username = req.Query["username"];

            Console.WriteLine($"Text send {text} with username {username}");

            var msg = new DiscordMessageRequest()
            {
                Content = $"User {username} posted: {text}",
                Tts = false
            };

            using HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://discord.com/")
            };

            using var msgApi = new HttpRequestMessage(HttpMethod.Post, $"api/channels/{DiscordChannelId}/messages");
            
            var rawMsg = JsonConvert.SerializeObject(msg, Formatting.Indented);

            msgApi.Content = new StringContent(rawMsg, Encoding.UTF8, "application/json");
            msgApi.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bot", DiscordBotToken);

            var response = await client.SendAsync(msgApi);

            var msgResponse = await response.Content.ReadAsStringAsync();
            var discordResult = JsonConvert.DeserializeObject<DiscordMessageResponse>(msgResponse);

            return new OkObjectResult(discordResult);
        }
    }
}
