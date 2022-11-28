namespace FeedMessages.API.Models
{
    public class CreateFeedViewModel
    {
        public string TopicName { get; set; } = "Default Topic";
        public string Content { get; set; } = "Default Content";
        public string Author { get; set; } = "Default Author";

        public CreateFeedViewModel(string topicName, string content, string author)
        {
            TopicName = topicName;
            Content = content;
            Author = author;
        }

        public CreateFeedViewModel()
        {
        }
    }
}

