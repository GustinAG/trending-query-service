using System;
using System.Collections.Generic;
using System.Linq;

namespace Trending.Query.Reporter
{
    public class Transformer
    {
        private const int TrendingArticleCount = 3;

        private readonly DateTime _shortTrendStartTime;
        private readonly IDictionary<int, SingleArticleTrend> _articles = new Dictionary<int, SingleArticleTrend>();

        public Transformer(DateTime shortTrendStartTime)
        {
            _shortTrendStartTime = shortTrendStartTime;
        }

        public void Load(IList<TrendingEvent> events)
        {
            Console.WriteLine($"Loading {events.Count} events...");
            foreach (var trendingEvent in events) Load(trendingEvent);
            Console.WriteLine("DONE.");
        }

        public int[] ShortTrendArticleIds => GetTrendArticleIds(t => t.ShortScore);
        public int[] LongTrendArticleIds => GetTrendArticleIds(t => t.LongScore);

        private void Load(TrendingEvent trendingEvent)
        {
            int articleId = trendingEvent.ArticleId;

            if (!_articles.ContainsKey(articleId)) _articles.Add(articleId, new SingleArticleTrend(_shortTrendStartTime));

            _articles[articleId].Add(trendingEvent.TimeStamp, trendingEvent.Score);
        }

        private int[] GetTrendArticleIds(Func<SingleArticleTrend, int> scoringFunc) =>
            _articles.OrderByDescending(a => scoringFunc(a.Value)).Take(TrendingArticleCount).Select(a => a.Key).ToArray();
    }
}
