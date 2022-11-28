using FeedMessages.Application.Interfaces.Infrastructure;
using FeedMessages.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Queries.GetFeed
{
    public class GetFeedHandler : IRequestHandler<GetFeedQuery, FeedDto?>
    {
        private readonly IQueryFeedInfrastructure _repository;

        public GetFeedHandler(IQueryFeedInfrastructure repository)
        {
            _repository = repository;
        }

        public async Task<FeedDto?> Handle(GetFeedQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }
    }
}
