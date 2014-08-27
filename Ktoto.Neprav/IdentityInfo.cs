using System.Web;
using Ktoto.Neprav.Utils;

namespace Ktoto.Neprav
{
    public class IdentityInfo
    {
	    private readonly bool _isAuthorized;
        private readonly Author _author;

        public IdentityInfo(AuthManager authManager)
        {
	        var ctx = HttpContext.Current;
			var author = authManager.FetchRemembered(ctx.Request);
            _isAuthorized = author != null;
            _author = author;
        }

        public bool IsAuthorized
        {
            get { return _isAuthorized; }
        }

        public Author Author
        {
            get { return _author; }
        }
    }
}