using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using Trending.Query.Dal;

namespace Trending.Query.Reporter.Tests
{
    [TestClass]
    public class TransformerUnitTests
    {
        [TestMethod]
        public void ShortTrendArticleIds_ShouldRankHigherScoreFirst()
        {
            // Arrange
            const int higherScoredArticleId = 4;
            var transformer = new Transformer(DateTime.UtcNow.AddDays(-1));
            var firstEvent = new TrendingEvent(CreateArticleEventDocument(higherScoredArticleId - 1, 3));
            var secondEvent = new TrendingEvent(CreateArticleEventDocument(higherScoredArticleId, 5));
            transformer.Load(new List<TrendingEvent> { firstEvent, secondEvent });

            // Act
            var trend = transformer.ShortTrendArticleIds;

            // Assert
            trend.Should().StartWith(higherScoredArticleId);
        }

        private static BsonDocument CreateArticleEventDocument(int articleId, int score) =>
            new BsonDocument
            {
                {ArticleTrendingEventsDal.TimeStampFieldName, new BsonDateTime(DateTime.UtcNow)},
                {TrendingEvent.ArticleIdFieldName, articleId},
                {TrendingEvent.ScoreFieldName, score}
            };
    }
}
