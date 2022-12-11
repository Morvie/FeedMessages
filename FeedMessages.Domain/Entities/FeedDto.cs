using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Domain.Entities
{
    public class FeedDto
    {
        public Guid Id { get; set; }
        public string TopicName { get; set; } = "Default Topic";
        public string Content { get; set; } = "Default Content";
        public string Author { get; set; } = "Default Author";
        public DateTime CreatedAt { get; set; } 
        public DateTime LastEdited { get; set; }
        public int MovieId { get; set; }

        public FeedDto(Guid id, string topicName, string content, string author, DateTime createdAt, DateTime lastEdited, int movieId)
        {
            Id = id;
            TopicName = topicName;
            Content = content;
            Author = author;
            CreatedAt = createdAt;
            LastEdited = lastEdited;
            MovieId = movieId;
        }

        public FeedDto()
        {
        }
    }
}
