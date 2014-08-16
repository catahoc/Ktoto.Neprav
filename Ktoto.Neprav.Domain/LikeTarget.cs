using System.Collections.Generic;

namespace Ktoto.Neprav.Domain
{
	public class LikeTarget
    {
		public LikeTarget()
		{
			Likes = new List<Like>();
		}

		public virtual long Id { get; set; }
		public virtual ICollection<Like> Likes { get; set; }
	}
}