using System;
using MongoDB.Bson;
using Trending.Query.Dal;

namespace Trending.Query.Reporter
{
    public class TrendingEvent
    {
        public const string ArticleIdFieldName = "article_Id";
        public const string ScoreFieldName = "score";

        public TrendingEvent(BsonDocument document)
        {
            TimeStamp = document[ArticleTrendingEventsDal.TimeStampFieldName].ToUniversalTime();
            ArticleId = document[ArticleIdFieldName].AsInt32;
            Score = document[ScoreFieldName].AsInt32;
        }

        internal DateTime TimeStamp { get; }
        internal int ArticleId { get; }
        internal int Score { get; }
    }
}
