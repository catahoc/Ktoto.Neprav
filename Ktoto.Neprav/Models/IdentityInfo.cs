using System;
using System.Linq;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Utils;

namespace Ktoto.Neprav.Models
{
	public interface IIdentityInfo
	{
		Author Author { get; }
	}

	public interface IIdentityInfoFactory
	{
		IIdentityInfo Create();
	}

	class IdentityInfoFactory : IIdentityInfoFactory
	{
		private readonly Lazy<IIdentityInfo> _identityInfo;

		public IdentityInfoFactory(IVkArgs args, IDal dal)
		{
			_identityInfo = new Lazy<IIdentityInfo>(() => CreateNew(args, dal));
		}

		public IIdentityInfo Create()
		{
			return _identityInfo.Value;
		}
		
		private IIdentityInfo CreateNew(IVkArgs args, IDal dal)
		{
			var author = dal.Query<Author>().SingleOrDefault(a => a.UserId == args.ViewerId);
			return new IdentityInfo(author);
		}
	}

	public class IdentityInfo : IIdentityInfo
	{
		public IdentityInfo(Author author)
		{
			Author = author;
		}

		public Author Author { get; set; }
	}
}