using System;
using System.Linq;
using System.Web;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav.Utils
{
    public class AuthManager
    {
        private const string AUTH_COOKIE = "author_name";

        public static void MarkResponse(HttpResponseBase response, Author author)
        {
            response.SetCookie(new HttpCookie(AUTH_COOKIE, Convert.ToString(author.Id)));
        }

        public static Author ImpersonateRequest(HttpRequest request, IDal dal)
        {
            var cookie = request.Cookies.Get(AUTH_COOKIE);
            if (cookie == null)
            {
                return null;
            }
            else
            {
                try
                {
                    return dal.Query<Author>().FirstOrDefault(_ => _.Id == Convert.ToInt32(cookie.Value));

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static void Logout(HttpResponseBase response)
        {
            response.SetCookie(new HttpCookie(AUTH_COOKIE, string.Empty) {Expires = DateTime.Now});
        }
    }
}