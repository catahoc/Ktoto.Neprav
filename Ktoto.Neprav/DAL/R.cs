using System.Linq;

namespace Ktoto.Neprav.DAL
{
    public static class R
    {
	    public static readonly OneToMany<Feed, Comment> FeedHasComments = new OneToMany<Feed, Comment>(_ => _.Comments, _ => _.Feed);
	    public static readonly OneToMany<Feed, Opinion> FeedHasOpinions = new OneToMany<Feed, Opinion>(_ => _.Opinions, _ => _.Feed);
		public static readonly OneToMany<Author, Opinion> AuthorHasOpinions = new OneToMany<Author, Opinion>(_ => _.Opinions, _ => _.Author);
		public static readonly OneToMany<Author, Feed> AuthorCreatedFeeds = new OneToMany<Author, Feed>(_ => _.Feeds, _ => _.Author);

	    public static void Commented(Author author, Feed feed, Comment comment)
        {
            AuthorCreatedFeeds.ParentReceivesChild(author, comment);
            FeedHasComments.ParentReceivesChild(feed, comment);
        }

	    public static void CreatedTheme(Author author, Theme theme)
	    {
		    AuthorCreatedFeeds.ParentReceivesChild(author, theme);
	    }
	    public static void CreatedComment(Author author, Feed parentFeed, Comment comment)
	    {
		    AuthorCreatedFeeds.ParentReceivesChild(author, comment);
			FeedHasComments.ParentReceivesChild(parentFeed, comment);
	    }
    }
}