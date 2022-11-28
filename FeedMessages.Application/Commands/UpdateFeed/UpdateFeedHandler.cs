using FeedMessages.Application.Interfaces.Infrastructure;
using FeedMessages.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Commands.UpdateFeed
{
    public class UpdateFeedHandler : IRequestHandler<UpdateFeedCommand, FeedDto?>
    {
        private readonly ICommandFeedInfrastructure _repository;

        public UpdateFeedHandler(ICommandFeedInfrastructure repository)
        {
            _repository = repository;
        }

        public async Task<FeedDto?> Handle(UpdateFeedCommand request, CancellationToken cancellationToken)
        {
            request.ExistingFeed.Id = request.ExistingId;
            request.ExistingFeed.LastEdited = DateTime.UtcNow;
            return await _repository.Update(request.ExistingFeed);
        }
    }
}
