using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Domain;
using Ktoto.Neprav.Models;
using Ktoto.Neprav.Attributes;
using Ktoto.Neprav.Utils;

namespace Ktoto.Neprav.Controllers
{
    public class AuthController : Controller
    {
        private readonly IDal _dal;

        public AuthController(IDal dal)
        {
            _dal = dal;
        }

        [AuthActionFilter(AuthRequiredOption.RequiresNotAuth)]
        public ActionResult Login(LoginModel loginModel)
        {
            var users = _dal.Query<Author>().Where(_ => _.Name == loginModel.User).ToList();
            if (users.Count == 1)
            {
                var author = users.Single();
                AuthManager.MarkResponse(Response, author);
                if (string.IsNullOrEmpty(loginModel.BackUrl))
                {
                    return RedirectToAction("Index", "Themes");
                }
                else
                {
                    return Redirect(loginModel.BackUrl);
                }
            }
            else
            {
                ModelState.AddModelError("login", "Ошибка входа. Повторите попытку");
                return View(loginModel);
            }
        }

        [AuthActionFilter(AuthRequiredOption.Required)]
        public ActionResult Logout(LogoutModel model)
        {
            AuthManager.Logout(Response);
            if (string.IsNullOrEmpty(model.BackUrl))
            {
                return RedirectToAction("Index", "Themes");
            }
            else
            {
                return Redirect(model.BackUrl);
            }
        }
    }
}
