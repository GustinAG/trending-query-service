using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Trending.Query.Dal
{
    public static class ArticleTrendingsDal
    {
        private const string MongoIp = "172.17.0.3";     // TODO: Fix this magic IP in Docker Compose!
        private const string MongoUrl = "mongodb://" + MongoIp + ":27017";
        private const string DbName = "articletrendings";
        private const string CollectionName = "trendings";

        public static TrendingsDto GetAll()
        {
            var dbClient = new MongoClient(MongoUrl);
            var db = dbClient.GetDatabase(DbName);
            var collection = db.GetCollection<BsonDocument>(CollectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("type", "short");
            var shortTrendingDocument = collection.Find(filter).FirstOrDefault();

            return new TrendingsDto
            {
                LongTrendingArticleIds = new[] { 2 },
                ShortTrendingArticleIds = shortTrendingDocument == null
                    ? new int[] { }
                    : shortTrendingDocument.AsBsonArray.Select(v => v.AsInt32).ToArray()
            };
        }
    }
}
