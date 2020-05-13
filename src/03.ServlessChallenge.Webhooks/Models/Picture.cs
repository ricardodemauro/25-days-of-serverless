using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ServlessChallenge.Webhooks.Models
{
    public class Picture
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }
    }
}
