using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav.Models
{
    public class CommentTheme
    {
        public string Text { get; set; }
		public long ThemeId { get; set; }
        public Opinion Opinion { get; set; }
    }
}