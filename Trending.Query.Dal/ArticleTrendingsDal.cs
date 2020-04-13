using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Trending.Query.Dal
{
    public sealed class ArticleTrendingsDal : TrendingDal
    {
        public ArticleTrendingsDal() : base(TrendingDatabase.Reporting, "trendings") { }

        public TrendingsDto GetAll()
        {
            var collection = GetCollection();
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
