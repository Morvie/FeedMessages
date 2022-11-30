using FeedMessages.Application.Interfaces.Infrastructure;
using FeedMessages.Application.Queries.GetAllFeeds;
using FeedMessages.Application.Queries.GetFeed;
using FeedMessages.Domain.Entities;
using FeedMessages.Test.Setup;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Test.UnitTest
{
    public class QueryTest
    {
        private readonly Mock<IQueryFeedInfrastructure> _mockRepo;
        public QueryTest() => _mockRepo = MockFeedRepository.MockRepository.GetRepository();

        [Fact]
        public async Task GetAllForums()
        {
            //Arrange
            var handler = new GetAllFeedsHandler(_mockRepo.Object);

            //Act
            var result = await handler.Handle(new GetAllFeedsQuery(), CancellationToken.None);

            //Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetSingleForum()
        {
            //Arrange
            var handler = new GetFeedHandler(_mockRepo.Object);
            var expected = new FeedDto() { Id = new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), TopicName = "Harry Potter & The Deathly Hallows Part 1 - Hagrid?!", Content = "Just Hagrid in the movie?!.", LastEdited = DateTime.MaxValue, CreatedAt = DateTime.MaxValue, Author = "Henk" };

            //Act
            var result = await handler.Handle(new GetFeedQuery(new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8")), CancellationToken.None);

            //Assert
            Assert.Equal(expected.ToString(), result.ToString());
        }

        [Fact]
        public async Task GetSingleForum_WithoutId()
        {
            //Arrange
            var handler = new GetFeedHandler(_mockRepo.Object);

            //Act
            var result = await handler.Handle(new GetFeedQuery(new Guid()), CancellationToken.None);

            //Assert
            Assert.Null(result);
        }
    }
}
