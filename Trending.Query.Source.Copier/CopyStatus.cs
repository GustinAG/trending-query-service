using System;
using MongoDB.Bson;
using Trending.Query.Dal;

namespace Trending.Query.Source.Copier
{
    internal class CopyStatus
    {
        private readonly ArticleTrendingEventsDal _operationalDal;
        private readonly ArticleTrendingEventsDal _reportingDal;

        internal CopyStatus(ArticleTrendingEventsDal operationalDal, ArticleTrendingEventsDal reportingDal)
        {
            _operationalDal = operationalDal;
            _reportingDal = reportingDal;
        }

        internal ObjectId LastCopiedId { get; private set; }
        internal ObjectId LastSourceId { get; private set; }
        internal bool AnythingNew => LastSourceId != TrendingDal.NoId && LastCopiedId != LastSourceId;

        internal void Check()
        {
            Console.WriteLine("Checking for new source records...");

            LastCopiedId = GetLastId(_reportingDal, "copied");
            LastSourceId = GetLastId(_operationalDal, "source");

            Console.WriteLine(AnythingNew ? "Now we got some new events to copy!" : "Nothing new to copy.");
        }

        private static ObjectId GetLastId(ArticleTrendingEventsDal dal, string displayAdjective)
        {
            var id = dal.GetLastId();
            Console.WriteLine($"Last {displayAdjective} event ID: '{id}'");
            return id;
        }
    }
}
