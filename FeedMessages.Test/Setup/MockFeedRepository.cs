using FeedMessages.Application.Interfaces.Infrastructure;
using FeedMessages.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Test.Setup
{
    public class MockFeedRepository
    {
        public interface IGuidService { Guid NewGuid(); }
        public static class MockRepository
        {
            public static Mock<IQueryFeedInfrastructure> GetRepository()
            {
                var mockGuidService = new Mock<IGuidService>();

                var forumstypes = new List<FeedDto>
                {
                new FeedDto() { Id = new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"), TopicName= "Is the Star-Wars - Rise of Empire movie good?", Content = "I don't think this is a good movie at all! It contains a lot of bad filming.",  LastEdited = DateTime.Now,CreatedAt = DateTime.Now, Author = "Henk"},
                new FeedDto() { Id = new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), TopicName = "Harry Potter & The Deathly Hallows Part 1 - Hagrid?!", Content = "Just Hagrid in the movie?!.", LastEdited = DateTime.MaxValue, CreatedAt = DateTime.Now, Author = "Petra" }
                };

                var mockRepo = new Mock<IQueryFeedInfrastructure>();

                mockRepo.Setup(r => r.GetAll()).ReturnsAsync(forumstypes);
                mockRepo.Setup(r => r.Get(new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"))).ReturnsAsync(new FeedDto() { Id = new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), TopicName = "Harry Potter & The Deathly Hallows Part 1 - Hagrid?!", Content = "Just Hagrid in the movie?!.", LastEdited = DateTime.MaxValue, CreatedAt = DateTime.Now, Author = "Petra" });

                return mockRepo;

            }
            public static Mock<ICommandFeedInfrastructure> CommandRepository()
            {
                var mockGuidService = new Mock<IGuidService>();

                var feeds = new List<FeedDto>
            {
                new FeedDto() { Id = new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"), TopicName= "Is the Star-Wars - Rise of Empire movie good?", Content = "I don't think this is a good movie at all! It contains a lot of bad filming.",  LastEdited = DateTime.Now,CreatedAt = DateTime.Now, Author = "Henk"},
                new FeedDto() { Id = new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), TopicName = "Harry Potter & The Deathly Hallows Part 1 - Hagrid?!", Content = "Just Hagrid in the movie?!.", LastEdited = DateTime.MaxValue, CreatedAt = DateTime.Now, Author = "Petra" }
            };

                var mockRepo = new Mock<ICommandFeedInfrastructure>();

                mockRepo.Setup(x => x.Create(It.IsAny<FeedDto>())).ReturnsAsync((FeedDto dto) =>
                {
                    feeds.Add(dto);
                    return dto;
                });

                return mockRepo;

            }
        }
    }
}
