using System;

namespace Ktoto.Neprav
{
	public class AuthCookie
	{
		public virtual long Id { get; set; }
		public virtual Guid Hash { get; set; }
		public virtual Author Author { get; set; }
	}
}