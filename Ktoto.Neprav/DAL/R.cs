using System.Linq;

namespace Ktoto.Neprav.DAL
{
    public class R
    {
	    public static readonly OneToMany<Feed, Comment> FeedHasComments = new OneToMany<Feed, Comment>(_ => _.Comments, _ => _.Feed);
	    public static readonly OneToMany<Feed, Opinion> FeedHasOpinions = new OneToMany<Feed, Opinion>(_ => _.Opinions, _ => _.Feed);
		public static readonly OneToMany<Author, Opinion> AuthorHasOpinions = new OneToMany<Author, Opinion>(_ => _.Opinions, _ => _.Author);
		public static readonly OneToMany<Author, Feed> AuthorCreatedFeeds = new OneToMany<Author, Feed>(_ => _.Feeds, _ => _.Author);

		private readonly IDal _dal;

	    public R(IDal dal)
	    {
		    _dal = dal;
	    }

	    public void Commented(Author author, Theme theme, Comment comment)
        {
            AuthorCreatedFeeds.ParentReceivesChild(author, comment);
            FeedHasComments.ParentReceivesChild(theme, comment);
        }

        public void CreatedTheme(Author author, Theme theme)
        {
            AuthorCreatedFeeds.ParentReceivesChild(author, theme);
        }

	    public void Like(Author author, Feed feed)
		{
			LeaveOpinion(author, feed, OpinionColor.Good);
	    }

		public void Unlike(Author author, Feed feed)
		{
			RemoveOpinion(author, feed, OpinionColor.Good);
		}

	    public void Dislike(Author author, Feed feed)
		{
			LeaveOpinion(author, feed, OpinionColor.Bad);
		}

		public void Undislike(Author author, Feed feed)
		{
			RemoveOpinion(author, feed, OpinionColor.Good);
		}

		private void RemoveOpinion(Author author, Feed feed, OpinionColor color)
		{
			var opinion = author.Opinions.SingleOrDefault(op => op.Feed == feed && op.Color == color);
			if (opinion != null)
			{
				_dal.Delete(opinion);
			}
		}

		private void LeaveOpinion(Author author, Feed feed, OpinionColor color)
	    {
		    var opinion = new Opinion
		    {
			    Author = author,
			    Feed = feed,
				Color = color
		    };
		    _dal.Attach(opinion);
	    }
    }
}