using System;
using Trending.Query.Dal;

namespace Trending.Query.Source.Copier
{
    internal static class Program
    {
        private static readonly IMongoConfig Config = new LocalDockerMongoConfig();

        // TODO: Index timestamp!
        // See e.g.: https://stackoverflow.com/questions/17807577/how-to-create-indexes-in-mongodb-via-net
        private static void Main()
        {
            Console.WriteLine($"Scheduled job: Trending Query Service ETL - SOURCE COPIER - (c) Gustin AG 2020 {Environment.NewLine}");

            var reportingDal = new ArticleTrendingEventsDal(Config, TrendingDatabase.Reporting);
            var operationalDal = new ArticleTrendingEventsDal(Config, TrendingDatabase.Operational);

            var copyStatus = new CopyStatus(operationalDal, reportingDal);
            copyStatus.Check();

            var copier = new Copier(operationalDal, reportingDal, copyStatus);
            copier.CopyNewEvents();
        }
    }
}
