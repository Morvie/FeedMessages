namespace FeedMessages.API.Models
{
    public class CreateFeedViewModel
    {
        public Guid ForumId { get; set; }
        public string TopicName { get; set; } = "Default Topic";
        public string Content { get; set; } = "Default Content";
        public string Author { get; set; } = "Default Author";
        public int MovieId { get; set; }

        public CreateFeedViewModel(Guid forumid,string topicName, string content, string author)
        {
            ForumId = forumid;
            TopicName = topicName;
            Content = content;
            Author = author;
        }

        public CreateFeedViewModel()
        {

        }
    }
}

