using FeedMessages.Application.Interfaces.Infrastructure;
using FeedMessages.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Commands.DeleteFeed
{
    public class DeleteFeedHandler : IRequestHandler<DeleteFeedCommand, FeedDto?>
    {
        private readonly ICommandFeedInfrastructure _repository;

        public DeleteFeedHandler(ICommandFeedInfrastructure repository)
        {
            _repository = repository;
        }

        public async Task<FeedDto?> Handle(DeleteFeedCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Delete(request.Id);
        }
    }
}
