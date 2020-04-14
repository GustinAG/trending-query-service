using System;
using System.Linq;
using Trending.Query.Dal;

namespace Trending.Query.Reporter
{
    internal class Extractor
    {
        private readonly ArticleTrendingEventsDal _dal;
        private readonly DateTime _shortTrendStartTime;

        internal Extractor(ArticleTrendingEventsDal dal, DateTime shortTrendStartTime)
        {
            _dal = dal;
            _shortTrendStartTime = shortTrendStartTime;
        }

        internal Transformer Extract(DateTime since)
        {
            Console.WriteLine($"Extracting events since {since:yyyy-MM-dd HH:mm:ss}...");

            var documents = _dal.GetAllSince(since);
            var events = documents.Select(d => new TrendingEvent(d)).ToList();
            Console.WriteLine($"{events.Count} events found.");

            var transformer = new Transformer(_shortTrendStartTime);
            transformer.Load(events);
            Console.WriteLine("Extracting events DONE.");

            return transformer;
        }
    }
}
