using System;
using System.Linq;
using System.Web;
using Ktoto.Neprav.Attributes;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Models;

namespace Ktoto.Neprav.Utils
{
    public class AuthManager
    {
	    private readonly IDal _dal;
	    private const string AuthCookie = "auth_hash";

	    public AuthManager(IDal dal)
	    {
		    _dal = dal;
	    }

	    public void MarkResponse(HttpResponseBase response, Author author)
	    {
		    var cookie = new AuthCookie
		    {
			    Author = author,
			    Hash = Guid.NewGuid()
		    };
			_dal.Attach(cookie);
            response.SetCookie(new HttpCookie(AuthCookie, Convert.ToString(cookie.Hash)));
        }

	    public Author ImpersonateRequest(HttpRequest request)
	    {
		    try
		    {
			    var cookie = request.Cookies.Get(AuthCookie);
			    if (cookie == null)
			    {
				    return null;
			    }
			    else
			    {
				    var hash = Guid.Parse(cookie.Value);
				    var authCookie = _dal.Query<AuthCookie>().SingleOrDefault(_ => _.Hash == hash);
				    if (authCookie != null)
				    {
					    return authCookie.Author;
				    }
				    else
				    {
					    return null;
				    }
			    }
		    }
		    catch (Exception)
		    {
			    return null;
		    }
	    }

	    public void Logout(HttpResponseBase response)
        {
            response.SetCookie(new HttpCookie(AuthCookie, string.Empty) {Expires = DateTime.Now});
        }

	    public bool CheckPwd(Author author, LoginModel loginModel)
	    {
		    return PwdManager.IsCorrect(new PwdManager.PwdData(author.Salt, author.PwdHash), loginModel.Password);
	    }
    }
}