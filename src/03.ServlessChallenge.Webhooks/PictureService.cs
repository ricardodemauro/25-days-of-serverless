using MongoDB.Driver;
using ServlessChallenge.Webhooks.Models;
using ServlessChallenge.Webhooks.MongoDb;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServlessChallenge.Webhooks
{
    public class PictureService
    {
        private readonly IMongoCollection<Picture> _pics;

        public PictureService(MongoDbOptions settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pics = database.GetCollection<Picture>(settings.Collection);
        }

        public List<Picture> Get() => _pics.Find(book => true).ToList();

        public async Task<Picture> Create(Picture data)
        {
            await _pics.InsertOneAsync(data);
            return data;
        }
    }
}
