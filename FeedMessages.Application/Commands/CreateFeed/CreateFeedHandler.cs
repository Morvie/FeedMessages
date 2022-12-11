using FeedMessages.Application.Interfaces.Infrastructure;
using FeedMessages.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Commands.CreateFeed
{
    public class CreateFeedHandler : IRequestHandler<CreateFeedCommand, FeedDto>
    {
        private readonly ICommandFeedInfrastructure _repository;

        public CreateFeedHandler(ICommandFeedInfrastructure repository)
        {
            _repository = repository;
        }

        public Task<FeedDto> Handle(CreateFeedCommand request, CancellationToken cancellationToken)
        {
            var thread = new FeedDto(Guid.NewGuid(), request.TopicName, request.Content, request.Author, DateTime.UtcNow, DateTime.UtcNow, request.MovieId);
            var result = _repository.Create(thread);
            return result;
        }
    }
}
