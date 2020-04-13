using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Trending.Query.Dal
{
    public sealed class ArticleTrendingEventsDal : TrendingDal
    {
        // ReSharper disable once StringLiteralTypo
        // This is the name of the collection without separator - according to MongoDB naming conventions.
        public ArticleTrendingEventsDal(TrendingDatabase database) : base(database, CollectionNameOf(database))
        { }

        public ObjectId GetLastId()
        {
            var collection = GetCollection();
            var sort = Builders<BsonDocument>.Sort.Descending(IdFieldName);
            var document = collection.Find(new BsonDocument()).Sort(sort).FirstOrDefault();

            return document == null ? NoId : ((BsonObjectId)(document[IdFieldName])).Value;
        }

        public IList<BsonDocument> GetAllNewerThan(ObjectId id)
        {
            var collection = GetCollection();
            var filter = Builders<BsonDocument>.Filter.Gt(IdFieldName, id);

            return collection.Find(filter).ToList();
        }

        public void InsertAll(IEnumerable<BsonDocument> documents)
        {
            var collection = GetCollection();
            collection.InsertMany(documents);
        }

        // ReSharper disable StringLiteralTypo
        // This is the name of the collection without separator - according to MongoDB naming conventions.
        private static string CollectionNameOf(TrendingDatabase database) =>
            database == TrendingDatabase.Operational ? "articleevents" : "articleeventscopy";
        // ReSharper restore StringLiteralTypo
    }
}
