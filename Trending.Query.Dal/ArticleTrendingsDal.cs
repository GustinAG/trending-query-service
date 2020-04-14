using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Trending.Query.Dal
{
    public sealed class ArticleTrendingsDal : TrendingDal
    {
        private const string TypeFieldName = "type";
        private const string IdsFieldName = "ids";
        private const string ShortType = "short";
        private const string LongType = "long";

        public ArticleTrendingsDal() : base(new LocalDockerMongoConfig(), TrendingDatabase.Reporting, "trendings") { }

        public TrendingsDto GetAll()
        {
            var collection = GetCollection();
            var shortTrendingDocument = GetTrendingDocument(collection, ShortType);
            var longTrendingDocument = GetTrendingDocument(collection, LongType);

            return new TrendingsDto
            {
                ShortTrendingArticleIds = GetIds(shortTrendingDocument),
                LongTrendingArticleIds = GetIds(longTrendingDocument)
            };
        }

        public void SaveAll(TrendingsDto dto)
        {
            var collection = GetCollection();
            Save(collection, ShortType, dto.ShortTrendingArticleIds);
            Save(collection, LongType, dto.LongTrendingArticleIds);
        }

        private void Save(IMongoCollection<BsonDocument> collection, string type, int[] articleIds)
        {
            var trending = new BsonDocument { { TypeFieldName, type }, { IdsFieldName, new BsonArray(articleIds) } };
            collection.ReplaceOne(GetTypeFilter(type), trending, new ReplaceOptions { IsUpsert = true });
        }

        private static BsonDocument GetTrendingDocument(IMongoCollection<BsonDocument> collection, string type) =>
            collection.Find(GetTypeFilter(type)).FirstOrDefault();

        private static FilterDefinition<BsonDocument> GetTypeFilter(string type) =>
            Builders<BsonDocument>.Filter.Eq(TypeFieldName, type);

        private static int[] GetIds(BsonDocument document) =>
            document == null
                ? new int[] { }
                : document[IdsFieldName].AsBsonArray.Select(v => v.AsInt32).ToArray();
    }
}
