namespace Trending.Query.Dal
{
    public sealed class LocalDockerMongoConfig : MongoConfig
    {
        private const string DockerIp = "172.17.0.3";    // TODO: Fix this magic IP in Docker Compose!

        public LocalDockerMongoConfig() : base(DockerIp)
        { }
    }
}
