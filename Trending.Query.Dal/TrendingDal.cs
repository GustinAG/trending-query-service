using MongoDB.Bson;
using MongoDB.Driver;

namespace Trending.Query.Dal
{
    public abstract class TrendingDal
    {
        public const string IdFieldName = "_id";

        private const string MongoIp = "172.17.0.3";     // TODO: Fix this magic IP in Docker Compose!
        private const string MongoUrl = "mongodb://" + MongoIp + ":27017";
        private const string OperationalDbName = "trendingevents";
        private const string ReportingDbName = "articletrendings";

        public static readonly ObjectId NoId = ObjectId.Empty;

        private readonly string _dbName;
        private readonly string _collectionName;

        protected TrendingDal(TrendingDatabase database, string collectionName)
        {
            _dbName = database == TrendingDatabase.Operational ? OperationalDbName : ReportingDbName;
            _collectionName = collectionName;
        }

        protected IMongoCollection<BsonDocument> GetCollection()
        {
            var dbClient = new MongoClient(MongoUrl);
            var db = dbClient.GetDatabase(_dbName);
            return db.GetCollection<BsonDocument>(_collectionName);
        }
    }
}
