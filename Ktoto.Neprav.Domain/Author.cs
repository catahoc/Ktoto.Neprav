using System.Collections.Generic;

namespace Ktoto.Neprav
{
    public class Author
    {
        public Author()
        {
            Themes = new List<Theme>();
            Comments = new List<Comment>();
			LikedTargets = new List<LikeTarget>();
        }

		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Email { get; set; }
		public virtual string Salt { get; set; }
		public virtual byte[] PwdHash { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<LikeTarget> LikedTargets { get; set; }
    }
}