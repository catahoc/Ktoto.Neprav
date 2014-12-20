using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Models;
using Ktoto.Neprav.Utils;

namespace Ktoto.Neprav.Controllers
{
    public class ThemesController : Controller
    {
        private readonly IDal _dal;
	    private readonly IIdentityInfo _identity;
	    private readonly IVkArgs _vkArgs;

	    public ThemesController(IDal dal, IIdentityInfoFactory factory, IVkArgs vkArgs)
        {
	        _dal = dal;
	        _identity = factory.Create();
		    _vkArgs = vkArgs;
        }

	    public ActionResult Index()
	    {
		    var theme = _dal.Query<Theme>().FirstOrDefault();
		    if (theme != null)
		    {
			    return RedirectToAction("Index", "Theme", new {themeId = theme.Id});
		    }
            return View();
        }

        public ActionResult Search(string text)
        {
            var found = _dal.Query<Theme>().Where(_ => _.Name.Contains(text)).ToList();
            return View(new FoundThemes(found, text));
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
				Created = DateTimeOffset.Now
			};
			_dal.Attach(theme);
			return RedirectToAction("Index", "Theme", new {themeId = theme.Id});
		}
    }
}
