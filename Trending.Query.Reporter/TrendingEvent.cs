using System;
using MongoDB.Bson;
using Trending.Query.Dal;

namespace Trending.Query.Reporter
{
    internal class TrendingEvent
    {
        internal TrendingEvent(BsonDocument document)
        {
            TimeStamp = document[ArticleTrendingEventsDal.TimeStampFieldName].ToUniversalTime();
            ArticleId = document["article_Id"].AsInt32;
            Score = document["score"].AsInt32;
        }

        internal DateTime TimeStamp { get; }
        internal int ArticleId { get; }
        internal int Score { get; }
    }
}
