using MongoDB.Bson;
using MongoDB.Driver;

namespace Trending.Query.Dal
{
    public abstract class TrendingDal
    {
        protected const string IdFieldName = "_id";

        private const string OperationalDbName = "trendingevents";
        private const string ReportingDbName = "articletrendings";

        public static readonly ObjectId NoId = ObjectId.Empty;

        private readonly string _dbName;
        private readonly IMongoConfig _config;
        private readonly string _collectionName;

        protected TrendingDal(IMongoConfig config, TrendingDatabase database, string collectionName)
        {
            _dbName = database == TrendingDatabase.Operational ? OperationalDbName : ReportingDbName;
            _config = config;
            _collectionName = collectionName;
        }

        protected IMongoCollection<BsonDocument> GetCollection()
        {
            var dbClient = new MongoClient(_config.MongoUrl);
            var db = dbClient.GetDatabase(_dbName);
            return db.GetCollection<BsonDocument>(_collectionName);
        }
    }
}
