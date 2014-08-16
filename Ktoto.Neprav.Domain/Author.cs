using System.Collections.Generic;

namespace Ktoto.Neprav.Domain
{
    public class Author
    {
        public Author()
        {
            Themes = new List<Theme>();
            Comments = new List<Comment>();
			Likes = new List<Like>();
        }

		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}