using System.Web;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Domain;
using Ktoto.Neprav.Utils;

namespace Ktoto.Neprav
{
    public class IdentityInfo
    {
        private readonly bool _isAuthorized;
        private readonly Author _author;

        public IdentityInfo(IDal dal)
        {
            var ctx = HttpContext.Current;
            var author = AuthManager.ImpersonateRequest(ctx.Request, dal);
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