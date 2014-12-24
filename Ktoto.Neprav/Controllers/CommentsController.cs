using System.Web.Mvc;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Models;

namespace Ktoto.Neprav.Controllers
{
	public class CommentsController: Controller
	{
		private readonly IDal _dal;
		private readonly IIdentityInfo _identity;

		public CommentsController(IDal dal, IIdentityInfo identity)
		{
			_dal = dal;
			_identity = identity;
		}

		public ActionResult Comment(CommentFeedModel commentModel)
		{
			var theme = _dal.Get<Theme>(commentModel.ThemeId);
			var feed = _dal.Get<Feed>(commentModel.FeedId);
			var comment = new Comment
			{
				Text = commentModel.Text,
				Color = commentModel.Color
			};
			R.Commented(_identity.Author, feed, comment);
			_dal.Attach(comment);

			return RedirectToAction("Index", "Theme", new { themeId = theme.Id });
		} 
	}
}