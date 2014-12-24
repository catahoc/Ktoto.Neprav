using System.Linq;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Utils;

namespace Ktoto.Neprav.Models
{
	internal class IdentityInfoFactory
	{
		private readonly IVkArgs _args;
		private readonly IDal _dal;

		public IdentityInfoFactory(IVkArgs args, IDal dal)
		{
			this._args = args;
			this._dal = dal;
		}

		public IIdentityInfo Create()
		{
			var author = _dal.Query<Author>().SingleOrDefault(a => a.UserId == _args.ViewerId);
			if (author == null)
			{
				author = new Author
				{
					UserId = _args.ViewerId
				};
				_dal.Attach(author);
			}
			return new IdentityInfo(author);
		}
	}
}