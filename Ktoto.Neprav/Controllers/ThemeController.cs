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
        private readonly OneToMany<Theme, Comment> _themeHasComments;

        public ThemeController(IDal dal, IdentityInfo identity, OneToMany<Theme, Comment> themeHasComments)
        {
            _dal = dal;
            _identity = identity;
            _themeHasComments = themeHasComments;
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
                    Author = _identity.Author,
                    Text = commentModel.Text,
                    Opinion = commentModel.Opinion
                };
            _dal.Attach(comment);

            _themeHasComments.ParentReceivesChild(theme, comment);
            return RedirectToAction("Index", new {name = theme.Name});
        }
    }
}
