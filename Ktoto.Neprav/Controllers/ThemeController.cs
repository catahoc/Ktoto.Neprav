﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Models;
using Ktoto.Neprav.Utils;

namespace Ktoto.Neprav.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IDal _dal;
	    private readonly IdentityInfo _identity;
	    private readonly R _r;

	    public ThemeController(IDal dal, IdentityInfo identity, R r)
        {
	        _dal = dal;
	        _identity = identity;
		    _r = r;
        }

	    public ActionResult Index(long themeId)
        {
            var theme = _dal.Get<Theme>(themeId);
            var model =
                new ThemeViewModel(
                    EnumHelpers.Enumerate<OpinionColor>()
                               .Select(
                                   _ =>
                                   new ThemeOpinionViewModel(_, theme.Comments.Where(c => c.Opinion == _).ToArray()))
                               .ToArray(),
                    theme);
            return View(model);
        }

        public ActionResult Comment(CommentTheme commentModel)
        {
            var theme = _dal.Get<Theme>(commentModel.ThemeId);
            var comment = new Comment
                {
                    Text = commentModel.Text,
                    Opinion = commentModel.Opinion
                };
			_r.Commented(_identity.Author, theme, comment);
            _dal.Attach(comment);

			return RedirectToAction("Index", new { themeId = theme.Id });
        }
    }
}
