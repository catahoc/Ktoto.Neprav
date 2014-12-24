using System;

namespace Ktoto.Neprav.Models
{
	public class IdentityInfo : IIdentityInfo
	{
		public IdentityInfo(Author author)
		{
			Author = author;
		}

		public Author Author { get; set; }
	}
}