using FeedMessages.Application.Interfaces.Infrastructure;
using FeedMessages.Domain.Entities;
using FeedMessages.Infrastructure.Context;
using Z.EntityFramework.Plus;

namespace FeedMessages.Infrastructure.Repository
{
    public class CommandFeedRepository : ICommandFeedInfrastructure
    {
        private readonly FeedDbContext _dbContext;

        public CommandFeedRepository(FeedDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FeedDto> Create(FeedDto thread)
        {
            await _dbContext.AddAsync(thread);
            await _dbContext.SaveChangesAsync();
            return thread;
        }

        public async Task<FeedDto?> Delete(Guid id)
        {
            var thread = await _dbContext.FeedsContext.FindAsync(id);
            await Task.WhenAll(_dbContext.FeedsContext
                .Where(m => m.Id == id).DeleteAsync(),
                _dbContext.SaveChangesAsync());
            return thread;
        }

        public async Task<FeedDto?> Update(FeedDto entity)
        {
            var existing = await _dbContext.FeedsContext.FindAsync(entity.Id);
            if (existing == null) return null;
            existing.TopicName = entity.TopicName;
            existing.Content = entity.Content;
            existing.LastEdited = entity.LastEdited;
            await _dbContext.SaveChangesAsync();
            return existing;
        }
    }
}
