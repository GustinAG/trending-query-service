using System;
using System.Collections.Generic;
using System.Text;

namespace Trending.Query.Reporter
{
    internal class Transformer
    {
        internal void Load(IList<TrendingEvent> events)
        {
            Console.WriteLine($"Loading {events.Count} events...");
        }
    }
}
