using System.Collections.Generic;

namespace Ktoto.Neprav
{
	public class Feed
    {
		public Feed()
		{
			Comments = new HashSet<Comment>();
			Opinions = new HashSet<Opinion>();
		}

		public virtual long Id { get; set; }
		public virtual Author Author { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<Opinion> Opinions { get; set; }
	}
}