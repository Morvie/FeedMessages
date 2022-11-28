namespace FeedMessages.API.Models
{
    public class UpdateFeedViewModel
    {
        public string TopicName { get; set; }
        public string Content { get; set; }
        public UpdateFeedViewModel(string topicName, string content)
        {
            TopicName = topicName;
            Content = content;
        }
    }
}
