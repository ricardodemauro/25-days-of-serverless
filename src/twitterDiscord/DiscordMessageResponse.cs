using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitterDiscord
{
    public class DiscordMessageResponse
    {
        public string id { get; set; }
        public int type { get; set; }
        public string content { get; set; }
        public string channel_id { get; set; }
        public Author author { get; set; }
        public object[] attachments { get; set; }
        public Embed[] embeds { get; set; }
        public object[] mentions { get; set; }
        public object[] mention_roles { get; set; }
        public bool pinned { get; set; }
        public bool mention_everyone { get; set; }
        public bool tts { get; set; }
        public DateTime timestamp { get; set; }
        public object edited_timestamp { get; set; }
        public int flags { get; set; }
    }

    public class Author
    {
        public string id { get; set; }
        public string username { get; set; }
        public object avatar { get; set; }
        public string discriminator { get; set; }
        public int public_flags { get; set; }
        public bool bot { get; set; }
    }

    public class Embed
    {
        public string type { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
