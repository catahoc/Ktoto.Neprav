using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Ktoto.Neprav.Utils
{
    public abstract class MyWebViewPage<TModel> : WebViewPage<TModel>
    {
        public IdentityInfo Identity { get; set; }

		public string This { get; set; }
    }

    public abstract class MyWebViewPage : WebViewPage
    {
        public IdentityInfo Identity { get; set; }

		public string This { get; set; }
	}
}