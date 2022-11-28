using FeedMessages.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Queries.GetFeed
{
    public class GetFeedQuery : IRequest<FeedDto>
    {
        public Guid Id { get; }

        public GetFeedQuery(Guid id)
        {
            Id = id;
        }
    }
}
