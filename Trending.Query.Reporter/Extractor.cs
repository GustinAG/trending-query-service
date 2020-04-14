using System;
using System.Linq;
using Trending.Query.Dal;

namespace Trending.Query.Reporter
{
    internal class Extractor
    {
        private readonly ArticleTrendingEventsDal _dal;

        internal Extractor(ArticleTrendingEventsDal dal)
        {
            _dal = dal;
        }

        internal Transformer Extract(DateTime from)
        {
            Console.WriteLine($"Extracting events from {from:yyyy-MM-dd HH:mm:ss}...");

            var documents = _dal.GetAllSince(from);
            var events = documents.Select(d => new TrendingEvent(d)).ToList();
            var transformer = new Transformer();

            transformer.Load(events);

            return transformer;
        }
    }
}
