using FeedMessages.Application.Interfaces.Infrastructure;
using FeedMessages.Domain.Entities;
using FeedMessages.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FeedMessages.Infrastructure.Repository
{
    public class QueryFeedRepository : IQueryFeedInfrastructure
    {
        private readonly FeedDbContext _dbContext;

        public QueryFeedRepository(FeedDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FeedDto>> GetAll()
        {
            return await _dbContext.FeedsContext.ToListAsync();
        }

        public async Task<FeedDto?> Get(Guid id)
        {
            return await _dbContext.FeedsContext.FindAsync(id);
        }
    }
}
