using System;

namespace Trending.Query.Reporter
{
    internal class SingleArticleTrend
    {
        private readonly DateTime _shortTrendStartTime;

        internal SingleArticleTrend(DateTime shortTrendStartTime)
        {
            _shortTrendStartTime = shortTrendStartTime;
        }

        internal void Add(DateTime timeStamp, int score)
        {
            LongScore += score;
            if (timeStamp > _shortTrendStartTime) ShortScore += score;
        }

        internal int ShortScore { get; private set; }
        internal int LongScore { get; private set; }
    }
}
