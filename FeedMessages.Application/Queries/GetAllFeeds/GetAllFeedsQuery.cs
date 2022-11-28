using FeedMessages.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Queries.GetAllFeeds
{
    public class GetAllFeedsQuery : IRequest<IEnumerable<FeedDto>>
    {

    }
}
