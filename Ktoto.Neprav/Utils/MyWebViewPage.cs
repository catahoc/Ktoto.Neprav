using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Ktoto.Neprav.Utils
{
    public abstract class MyWebViewPage<TModel> : WebViewPage<TModel>
    {
		public string This { get; set; }
    }

    public abstract class MyWebViewPage : WebViewPage
    {
		public string This { get; set; }
	}
}