using FeedMessages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Interfaces.Infrastructure
{
    public interface ICommandFeedInfrastructure
    {
        Task<FeedDto> Create(FeedDto entity);
        Task<FeedDto?> Delete(Guid id);
        Task<FeedDto?> Update(FeedDto entity);
    }
}
