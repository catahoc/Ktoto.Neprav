using System.EnterpriseServices.Internal;
using Ktoto.Neprav.Attributes;
using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav.DAL
{
    public static class R
    {
        public static readonly OneToMany<Theme, Comment> ThemeHasComments = new OneToMany<Theme, Comment>(_ => _.Comments, _ => _.Theme);
        public static readonly OneToMany<Author, Comment> AuthorHasComments = new OneToMany<Author, Comment>(_ => _.Comments, _ => _.Author);
        public static readonly OneToMany<Author, Theme> AuthorCreatedSomeThemes = new OneToMany<Author, Theme>(_ => _.Themes, _ => _.Author);
		public static readonly ManyToMany<Author, LikeTarget> AuthorLikedManyThings = new ManyToMany<Author, LikeTarget>(_ => _.LikedTargets, _ => _.LikedAuthors);

        public static void Commented(Author author, Theme theme, Comment comment)
        {
            AuthorHasComments.ParentReceivesChild(author, comment);
            ThemeHasComments.ParentReceivesChild(theme, comment);
        }

        public static void CreatedTheme(Author author, Theme theme)
        {
            AuthorCreatedSomeThemes.ParentReceivesChild(author, theme);
        }

	    public static void Liked(Author author, LikeTarget target)
	    {
		    AuthorLikedManyThings.Bind(author, target);
	    }

	    public static void Disliked(Author author, LikeTarget target)
	    {
		    AuthorLikedManyThings.Unbind(author, target);
	    }
    }
}