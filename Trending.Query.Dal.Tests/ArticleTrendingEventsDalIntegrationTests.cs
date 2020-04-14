using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trending.Query.Dal.Tests
{
    [TestClass]
    public class ArticleTrendingEventsDalIntegrationTests
    {
        private const string LocalIp = "127.0.0.1";
        private static readonly IMongoConfig Config = new MongoConfig(LocalIp);

        [TestMethod]
        public void GetAllSince_ShouldReturnSomething()
        {
            // Arrange
            var dal = new ArticleTrendingEventsDal(Config, TrendingDatabase.Reporting);
            var from = DateTime.UtcNow.AddDays(-5);

            // Act
            var documents = dal.GetAllSince(from);

            // Assert
            documents.Should().NotBeNullOrEmpty("there should be something in the source copy");
        }
    }
}
