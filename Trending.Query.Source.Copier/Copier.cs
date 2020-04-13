using System;
using System.Linq;
using Trending.Query.Dal;

namespace Trending.Query.Source.Copier
{
    internal class Copier
    {
        private readonly ArticleTrendingEventsDal _operationalDal;
        private readonly ArticleTrendingEventsDal _reportingDal;
        private readonly CopyStatus _status;

        internal Copier(ArticleTrendingEventsDal operationalDal, ArticleTrendingEventsDal reportingDal, CopyStatus status)
        {
            _operationalDal = operationalDal;
            _reportingDal = reportingDal;
            _status = status;
        }

        internal void CopyNewEvents()
        {
            if (!_status.AnythingNew) return;

            var newEvents = _operationalDal.GetAllNewerThan(_status.LastCopiedId);

            if (!newEvents.Any())
            {
                Console.WriteLine("That's ridiculous - no new event found!");
                return;
            }

            Console.WriteLine($"Copying {newEvents.Count} new events...");
            _reportingDal.InsertAll(newEvents);
            Console.WriteLine("DONE.");
        }
    }
}
