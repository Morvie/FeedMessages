using FeedMessages.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Commands.UpdateFeed
{
    public class UpdateFeedCommand: IRequest<FeedDto>
    {
        public Guid ExistingId { get; }
        public FeedDto ExistingFeed { get; }

        public UpdateFeedCommand(Guid existingId, FeedDto existingfeed)
        {
            ExistingId = existingId;
            ExistingFeed = existingfeed;
        }
    }
}
