using System.Collections.Generic;

namespace Ktoto.Neprav
{
	public class LikeTarget
    {
		public LikeTarget()
		{
			LikedAuthors = new List<Author>();
		}

		public virtual long Id { get; set; }
		public virtual ICollection<Author> LikedAuthors { get; set; }
	}
}