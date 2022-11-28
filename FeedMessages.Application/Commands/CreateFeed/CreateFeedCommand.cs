using FeedMessages.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Commands.CreateFeed
{
    public class CreateFeedCommand : IRequest<FeedDto>
    {
        public string Author { get; } = "Default Author";
        public string TopicName { get; } = "Default Topic";
        public string Content { get; } = "Default Description";

        public CreateFeedCommand(string author, string topicName, string content)
        {
            Author = author;
            TopicName = topicName;
            Content = content;
        }
    }
}
