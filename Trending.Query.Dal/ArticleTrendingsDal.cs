using System;
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
            var shortTrendingDocument = GetTrendingDocument(collection, "short");
            var longTrendingDocument = GetTrendingDocument(collection, "long");

            return new TrendingsDto
            {
                ShortTrendingArticleIds = GetIds(shortTrendingDocument),
                LongTrendingArticleIds = GetIds(longTrendingDocument)
            };
        }

        private static BsonDocument GetTrendingDocument(IMongoCollection<BsonDocument> collection, string type)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("type", type);
            return collection.Find(filter).FirstOrDefault();
        }

        private static int[] GetIds(BsonDocument document) =>
            document == null
                ? new int[] { }
                : document["ids"].AsBsonArray.Select(v => v.AsDouble).Select(Convert.ToInt32).ToArray();
    }
}
