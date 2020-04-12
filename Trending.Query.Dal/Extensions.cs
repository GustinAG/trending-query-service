using System;
using System.Linq;
using MongoDB.Bson;

namespace Trending.Query.Dal
{
    internal static class Extensions
    {
        internal static int[] ToIntArray(this BsonDocument document)
        {
            if (document == null) return new int[] { };

            return document["ids"].AsBsonArray.Select(v => v.AsDouble).Select(Convert.ToInt32).ToArray();
        }
    }
}
