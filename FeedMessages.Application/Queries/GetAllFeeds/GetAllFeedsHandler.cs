using FeedMessages.Application.Interfaces.Infrastructure;
using FeedMessages.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Queries.GetAllFeeds
{
    public class GetAllFeedsHandler : IRequestHandler<GetAllFeedsQuery, IEnumerable<FeedDto>>
    {
        private readonly IQueryFeedInfrastructure _repository;

        public GetAllFeedsHandler(IQueryFeedInfrastructure repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FeedDto>> Handle(GetAllFeedsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
