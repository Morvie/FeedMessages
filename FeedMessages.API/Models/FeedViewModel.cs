namespace FeedMessages.API.Models
{
    public class FeedViewModel
    {
        public Guid Id { get; set; }
        public string? TopicName { get; set; } = "Default Topic";
        public string? Content { get; set; } = "Default Content";
        public string? Author { get; set; } = "Default Author";
        public DateTime CreatedAt { get; set; } 
        public DateTime LastEdited { get; set; }
        public int MovieId { get; set; }

        public FeedViewModel(Guid id, string topicName, string content, string author, DateTime createdAt, DateTime lastEdited, int movieId)
        {
            Id = id;
            TopicName = topicName;
            Content = content;
            Author = author;
            CreatedAt = createdAt;
            LastEdited = lastEdited;
            MovieId = movieId;
        }
    }
}
