using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitterDiscord
{
    public class DiscordMessageRequest
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("tts")]
        public bool Tts { get; set; }
    }
}
