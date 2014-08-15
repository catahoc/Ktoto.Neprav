using System;
using System.Web.Mvc;

namespace Ktoto.Neprav.Attributes
{
    public enum AuthRequiredOption
    {
        Required,
        NotRequired,
        RequiresNotAuth
    }

    public class AuthActionFilter: ActionFilterAttribute
    {
        private readonly AuthRequiredOption _option;
        private readonly IdentityInfo _identity;

        public AuthActionFilter(AuthRequiredOption option)
        {
            _option = option;
            var resolver = DependencyResolver.Current;
            _identity = resolver.GetService<IdentityInfo>();
        }

        public string TargetRole { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_option == AuthRequiredOption.Required && !_identity.IsAuthorized)
            {
                throw new Exception("Надо залоггироваться");
            }
            if (_option == AuthRequiredOption.RequiresNotAuth && _identity.IsAuthorized)
            {
                throw new Exception("Надо выйти");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}