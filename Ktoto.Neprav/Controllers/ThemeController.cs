using System;
using System.Linq;
using System.Web.Mvc;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Models;
using Ktoto.Neprav.Utils;

namespace Ktoto.Neprav.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IDal _dal;
	    private readonly IIdentityInfo _identity;

	    public ThemeController(IDal dal, IIdentityInfo identity)
        {
	        _dal = dal;
			_identity = identity;
        }

	    public ActionResult Index(long themeId)
        {
            var theme = _dal.Get<Theme>(themeId);
            var model =
                new ThemeViewModel(
                    EnumHelpers.Enumerate<OpinionColor>()
                               .Select(
                                   _ =>
                                   new ThemeOpinionViewModel(_, theme.Comments.Where(c => c.Color == _).ToArray()))
                               .ToArray(),
                    theme);
            return View(model);
        }

		public ActionResult Create()
		{
			return View();
		}

		public ActionResult AcceptCreate(string name)
		{
			var theme = new Theme
			{
				Name = name,
				Created = DateTimeOffset.Now,
				Author = _identity.Author
			};
			_dal.Attach(theme);
			return RedirectToAction("Index", "Theme", new { themeId = theme.Id });
		}
    }
}
