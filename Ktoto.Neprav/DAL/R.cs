using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav.DAL
{
    public static class R
    {
        public static OneToMany<Theme, Comment> ThemeHasComments = new OneToMany<Theme, Comment>(_ => _.Comments, _ => _.Theme);
        public static OneToMany<Author, Comment> AuthorHasComments = new OneToMany<Author, Comment>(_ => _.Comments, _ => _.Author);
        public static OneToMany<Author, Theme> AuthorHasThemes = new OneToMany<Author, Theme>(_ => _.Themes, _ => _.Author);

        public static void Commented(Author author, Theme theme, Comment comment)
        {
            AuthorHasComments.ParentReceivesChild(author, comment);
            ThemeHasComments.ParentReceivesChild(theme, comment);
        }

        public static void CreatedTheme(Author author, Theme theme)
        {
            AuthorHasThemes.ParentReceivesChild(author, theme);
        }
    }
}