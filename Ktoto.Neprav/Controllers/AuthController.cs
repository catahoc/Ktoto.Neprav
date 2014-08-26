using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Models;
using Ktoto.Neprav.Attributes;
using Ktoto.Neprav.Utils;

namespace Ktoto.Neprav.Controllers
{
    public class AuthController : Controller
    {
        private readonly IDal _dal;
	    private readonly AuthManager _authManager;

	    public AuthController(IDal dal, AuthManager authManager)
        {
	        _dal = dal;
	        _authManager = authManager;
        }

	    [Auth(AuthRequiredOption.RequiresNotAuth)]
        public ActionResult Login(LoginModel loginModel)
        {
            var users = _dal.Query<Author>().Where(_ => _.Email == loginModel.Mail).ToList();
            if (users.Count == 1)
            {
                var author = users.Single();
				if (_authManager.CheckPwd(author, loginModel))
	            {
					_authManager.MarkResponse(Response, author);
					if (string.IsNullOrEmpty(loginModel.BackUrl))
					{
						return RedirectToAction("Index", "Themes");
					}
					else
					{
						return Redirect(loginModel.BackUrl);
					}
				}
            }

	        ModelState.AddModelError("login", "Ошибка входа. Повторите попытку");
	        return View(loginModel);
        }

        [Auth(AuthRequiredOption.Required)]
        public ActionResult Logout(LogoutModel model)
        {
			_authManager.Logout(Response);
            if (string.IsNullOrEmpty(model.BackUrl))
            {
                return RedirectToAction("Index", "Themes");
            }
            else
            {
                return Redirect(model.BackUrl);
            }
        }

		[Auth(AuthRequiredOption.RequiresNotAuth)]
	    public ActionResult Register()
		{
			return View();
		}

	    public ActionResult AcceptRegister(RegistrationInfo registration)
	    {
		    var hashSalt = PwdManager.ComputeHash(registration.Pwd);
		    var author = new Author
		    {
			    Email = registration.Email,
			    Name = registration.Email,
			    PwdHash = hashSalt.Hash,
			    Salt = hashSalt.Salt,
			    Sex = Sex.Male
		    };
			_dal.Attach(author);
			_authManager.MarkResponse(Response, author);
		    return RedirectToAction("RegistrationSuccessful");
	    }

		[Auth(AuthRequiredOption.Required)]
	    public ActionResult RegistrationSuccessful()
		{
			return View();
		}
    }
}
