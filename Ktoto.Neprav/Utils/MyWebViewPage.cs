using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Ktoto.Neprav.Utils
{
    public abstract class MyWebViewPage<TModel> : WebViewPage<TModel>
    {
        [Dependency]
        public IdentityInfo Identity { get; set; }
    }

    public abstract class MyWebViewPage : WebViewPage
    {
        [Dependency]
        public IdentityInfo Identity { get; set; }
    }
}