using System.Web.Mvc;
using Ktoto.Neprav.Models;
using Microsoft.Practices.Unity;

namespace Ktoto.Neprav.Utils
{
    public abstract class MyWebViewPage<TModel> : WebViewPage<TModel>
    {
		public string This { get; set; }

		public IVkArgs VkArgs { get; set; }
		public IIdentityInfo IdentityInfo { get; set; }
    }

    public abstract class MyWebViewPage : WebViewPage
    {
		public string This { get; set; }
		public IVkArgs VkArgs { get; set; }
		public IIdentityInfo IdentityInfo { get; set; }
	}
}