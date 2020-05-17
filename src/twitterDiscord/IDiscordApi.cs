using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitterDiscord
{
    public interface IDiscordApi
    {
        [Headers("ContentType: application/json")]
        [Post("/channels/{channelId}/messages")]
        Task<DiscordMessageResponse> PostMessage(string channelId, 
            [Body] DiscordMessageRequest request, 
            [Header("Authorization")]string authorizationHeader);
    }
}
