using System;
using Trending.Query.Dal;

namespace Trending.Query.Reporter
{
    internal static class Program
    {
        private const int ShortTrendHours = 1;
        private const int LongTrendHours = 12;

        private static void Main()
        {
            Console.WriteLine($"Scheduled job: Trending Query Service ETL - REPORTER - (c) Gustin AG 2020 {Environment.NewLine}");

            var sourceDal = new ArticleTrendingEventsDal(new LocalDockerMongoConfig(), TrendingDatabase.Reporting);
            var destinationDal = new ArticleTrendingsDal();

            var now = DateTime.UtcNow;
            var shortTrendStartTime = now.AddHours(-ShortTrendHours);
            var longTrendStartTime = now.AddHours(-LongTrendHours);

            var extractor = new Extractor(sourceDal, shortTrendStartTime);
            var transformer = extractor.Extract(longTrendStartTime);
            var shortTrendArticleIds = transformer.ShortTrendArticleIds;
            var longTrendArticleIds = transformer.LongTrendArticleIds;

            DisplayArticleIds("Short", shortTrendArticleIds);
            DisplayArticleIds("Long", longTrendArticleIds);
        }

        private static void DisplayArticleIds(string which, int[] articleIds)
        {
            var ids = string.Join(", ", articleIds);
            Console.WriteLine($"{which} trend: [{ids}]");
        }
    }
}
