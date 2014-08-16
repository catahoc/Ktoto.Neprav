using System.Collections.Generic;

namespace Ktoto.Neprav.Domain
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