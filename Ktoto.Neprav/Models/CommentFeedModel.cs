namespace Ktoto.Neprav.Models
{
    public class CommentFeedModel
    {
        public string Text { get; set; }
		public long FeedId { get; set; }
		public long ThemeId { get; set; }
        public OpinionColor Color { get; set; }
    }
}