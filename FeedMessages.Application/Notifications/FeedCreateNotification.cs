using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Notifications
{
    public class FeedCreateNotification : INotification
    {        
        public Guid Id { get; init; }
        public Guid ForumId { get; init; }
        public string TopicName { get; init; } = "Default Topic";
        public string Content { get; init; } = "Default Content";
        public string Author { get; init; } = "Default Author";
        public DateTime CreatedAt { get; init; }
        public DateTime LastEdited { get; init; }
    }
}

