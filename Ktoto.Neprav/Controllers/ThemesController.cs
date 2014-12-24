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

	    public ThemesController(IDal dal, IIdentityInfo identity)
        {
	        _dal = dal;
			_identity = identity;
        }

	    public ActionResult Index()
	    {
		    var weekAgo = DateTime.Now - TimeSpan.FromDays(7);
		    var themes = _dal.Query<Theme>().OrderByDescending(t => t.Comments.Count).Take(10);
		    return View(themes);
	    }

        public ActionResult Search(string text)
        {
            var found = _dal.Query<Theme>().Where(_ => _.Name.Contains(text)).ToList();
            return View(new FoundThemes(found, text));
        }
    }
}
