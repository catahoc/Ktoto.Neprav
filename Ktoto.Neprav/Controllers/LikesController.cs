using System.Web.Mvc;
using Ktoto.Neprav.Attributes;
using Ktoto.Neprav.DAL;

namespace Ktoto.Neprav.Controllers
{
	public class LikesController : Controller
	{
		private readonly IDal _dal;
		private readonly IdentityInfo _identity;

		public LikesController(IDal dal, IdentityInfo identity)
		{
			_dal = dal;
			_identity = identity;
		}

		[Auth(AuthRequiredOption.Required)]
		public ActionResult Like(long targetId, string backurl)
		{
			var target = _dal.Get<LikeTarget>(targetId);
			R.Liked(_identity.Author, target);
			return Redirect(backurl);
		}

		[Auth(AuthRequiredOption.Required)]
		public ActionResult Dislike(long targetId, string backurl)
		{
			var target = _dal.Get<LikeTarget>(targetId);
			R.Disliked(_identity.Author, target);
			return Redirect(backurl);
		}
	}
}