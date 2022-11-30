using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Notifications
{
    public class FeedHandlerCreated : INotificationHandler<FeedCreateNotification>
    {
        private readonly ISendEndpointProvider _publisher;

        public FeedHandlerCreated(ISendEndpointProvider publisher)
        {
            _publisher = publisher;
        }

        public async Task Handle(FeedCreateNotification notification, CancellationToken cancellationToken)
        {
            var endpoint = await _publisher.GetSendEndpoint(new Uri("queue:feed-created---queue"));
            await endpoint.Send(new FeedCreateNotification()
            {
                Id = notification.Id,
                ForumId = notification.ForumId,
                TopicName = notification.TopicName,
                Content = notification.Content,
                Author = notification.Author,
                CreatedAt = notification.CreatedAt,
                LastEdited = notification.LastEdited
            }, context =>
            {
                context.CorrelationId = notification.ForumId;
            }, cancellationToken: cancellationToken);
        }
    }
}
