namespace Trending.Query.Dal
{
    public class MongoConfig : IMongoConfig
    {
        private readonly string _ip;

        public MongoConfig(string ip)
        {
            _ip = ip;
        }

        public string MongoUrl => $"mongodb://{_ip}:27017";
    }
}
