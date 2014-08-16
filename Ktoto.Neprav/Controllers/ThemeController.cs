using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ktoto.Neprav.Attributes;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Domain;
using Ktoto.Neprav.Images;
using Ktoto.Neprav.Models;
using Ktoto.Neprav.Utils;

namespace Ktoto.Neprav.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IDal _dal;
        private readonly IdentityInfo _identity;

        public ThemeController(IDal dal, IdentityInfo identity)
        {
            _dal = dal;
            _identity = identity;
        }

        public ActionResult Index(string name)
        {
            var theme = _dal.Query<Theme>().Single(_ => _.Name == name);
            var model =
                new ThemeViewModel(
                    EnumHelpers.Enumerate<Opinion>()
                               .Select(
                                   _ =>
                                   new ThemeOpinionViewModel(_, theme.Comments.Where(c => c.Opinion == _).ToArray()))
                               .ToArray(),
                    theme);
            return View(model);
        }

        [AuthActionFilter(AuthRequiredOption.Required)]
        public ActionResult Comment(CommentTheme commentModel)
        {
            var theme = _dal.Query<Theme>().Single(_ => _.Name == commentModel.ThemeName);
            var comment = new Comment
                {
                    Text = commentModel.Text,
                    Opinion = commentModel.Opinion
                };
			R.Commented(_identity.Author, theme, comment);
            _dal.Attach(comment);

            return RedirectToAction("Index", new {name = theme.Name});
        }
    }
}
