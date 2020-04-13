using System;
using Trending.Query.Dal;

namespace Trending.Query.Source.Copier
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine($"Scheduled job: Trending Query Service ETL - SOURCE COPIER - (c) Gustin AG 2020 {Environment.NewLine}");

            var reportingDal = new ArticleTrendingEventsDal(TrendingDatabase.Reporting);
            var operationalDal = new ArticleTrendingEventsDal(TrendingDatabase.Operational);

            var copyStatus = new CopyStatus(operationalDal, reportingDal);
            copyStatus.Check();

            var copier = new Copier(operationalDal, reportingDal, copyStatus);
            copier.CopyNewEvents();
        }
    }
}
