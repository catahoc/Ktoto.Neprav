using System.Collections.Generic;

namespace Ktoto.Neprav
{
	public class Author
	{
		public Author()
		{
			Feeds = new HashSet<Feed>();
			Opinions = new HashSet<Opinion>();
		}

		public virtual long Id { get; set; }

		public virtual long UserId { get; set; }

		public virtual ICollection<Feed> Feeds { get; set; }
		public virtual ICollection<Opinion> Opinions { get; set; }
	}
}