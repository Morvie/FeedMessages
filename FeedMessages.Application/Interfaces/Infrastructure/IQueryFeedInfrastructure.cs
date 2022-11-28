using FeedMessages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Interfaces.Infrastructure
{
    public interface IQueryFeedInfrastructure
    {
        Task<IEnumerable<FeedDto>> GetAll();
        Task<FeedDto?> Get(Guid id);
    }
}
