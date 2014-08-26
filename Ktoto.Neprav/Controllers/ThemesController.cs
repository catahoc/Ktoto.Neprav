using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ktoto.Neprav.Attributes;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Models;

namespace Ktoto.Neprav.Controllers
{
    public class ThemesController : Controller
    {
        private readonly IDal _dal;
	    private readonly IdentityInfo _identity;

	    public ThemesController(IDal dal, IdentityInfo identity)
        {
	        _dal = dal;
	        _identity = identity;
        }

	    public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string text)
        {
            var found = _dal.Query<Theme>().Where(_ => _.Name.Contains(text)).ToList();
            return View(new FoundThemes(found, text));
        }

		[Auth(AuthRequiredOption.Required)]
	    public ActionResult Create()
	    {
		    return View();
	    }

		[Auth(AuthRequiredOption.Required)]
		public ActionResult AcceptCreate(string name)
		{
			var theme = new Theme
			{
				Author = _identity.Author,
				Name = name,
				Created = DateTimeOffset.Now
			};
			_dal.Attach(theme);
			return RedirectToAction("Index", "Theme", new {themeId = theme.Id});
		}
    }
}
