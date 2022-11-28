using FeedMessages.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Commands.DeleteFeed
{
    public class DeleteFeedCommand : IRequest<FeedDto?>
    {
        public Guid Id { get; }

        public DeleteFeedCommand(Guid id)
        {
            Id = id;
        }
    }
}
