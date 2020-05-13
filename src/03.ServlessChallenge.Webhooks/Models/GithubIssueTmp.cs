using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServlessChallenge.Webhooks.Models
{
    public class GithubIssueTmp
    {
        public string Action { get; set; }

        public Comment Comment { get; set; }

        public Sender Sender { get; set; }
    }

    public class Comment
    {
        public string Body { get; set; }
    }

    public class Sender
    {
        public string Login { get; set; }
    }
}
