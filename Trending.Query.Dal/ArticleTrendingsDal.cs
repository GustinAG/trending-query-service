using MongoDB.Bson;
using MongoDB.Driver;

namespace Trending.Query.Dal
{
    public static class ArticleTrendingsDal
    {
        private const string MongoIp = "172.17.0.4";     // TODO: Fix this magic IP in Docker Compose!
        private const string MongoUrl = "mongodb://" + MongoIp + ":27017";
        private const string DbName = "articletrendings";
        private const string CollectionName = "trendings";

        public static TrendingsDto GetAll()
        {
            var dbClient = new MongoClient(MongoUrl);
            var db = dbClient.GetDatabase(DbName);
            var collection = db.GetCollection<BsonDocument>(CollectionName);
            var documents = collection.Find(new BsonDocument()).ToList();

            var dto = new TrendingsDto { ShortTrendingArticleIds = new[] { 1, 3 }, LongTrendingArticleIds = new[] { 2 } };
            return dto;
        }
    }
}
