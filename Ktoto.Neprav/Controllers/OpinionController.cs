using System.Linq;
using System.Web.Mvc;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Models;

namespace Ktoto.Neprav.Controllers
{
	public class OpinionController: Controller
	{
		private readonly IDal _dal;
		private readonly IIdentityInfo _identity;

		public OpinionController(IDal dal, IIdentityInfo identity)
		{
			_dal = dal;
			_identity = identity;
		}

		public ActionResult Click(long themeId, long feedId, OpinionColor color)
		{
			var feed = _dal.Get<Feed>(feedId);
			var author = _identity.Author;
			var hisOpinion = feed.Opinions.SingleOrDefault(o => o.Author == author);
			if (hisOpinion == null)
			{
				CreateOpinion(color, feed);
			}
			else if (hisOpinion.Color == color)
			{
				RemoveOpinion(hisOpinion, feed);
			}
			else
			{
				RemoveOpinion(hisOpinion, feed);
				CreateOpinion(color, feed);
			}

			return RedirectToAction("Index", "Theme", new {themeId = themeId});
		}

		private void RemoveOpinion(Opinion hisOpinion, Feed feed)
		{
			R.FeedHasOpinions.ParentReceivesChild(feed, hisOpinion);
			R.AuthorHasOpinions.ParentReceivesChild(_identity.Author, hisOpinion);
			_dal.Delete(hisOpinion);
		}

		private void CreateOpinion(OpinionColor color, Feed feed)
		{
			var opinion = new Opinion
			{
				Color = color
			};
			_dal.Attach(opinion);
			R.FeedHasOpinions.ParentReceivesChild(feed, opinion);
			R.AuthorHasOpinions.ParentReceivesChild(_identity.Author, opinion);
		}
	}
}