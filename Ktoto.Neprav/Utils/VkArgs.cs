using System.Web;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Ktoto.Neprav.Utils
{
	public class VkArgs : IVkArgs
	{
		public VkArgs(IVkArgsSource source, HttpRequest request, HttpResponse response)
		{
			var args = source.GetVkArgs(request, response);
			ApiUrl = args.GetOrNull("vk.api_url");
			ViewerId = args.GetOrNull("vk.viewer_id");
			ApiId = args.GetOrNull("vk.api_id");
			Sid = args.GetOrNull("vk.sid");
			Secret = args.GetOrNull("vk.secret");
			Language = args.GetOrNull("vk.language");
			AccessToken = args.GetOrNull("vk.access_token");
		}

		public string ApiUrl { get; private set; }
		public string ApiId { get; private set; }
		public string Sid { get; private set; }
		public string Secret { get; private set; }
		public string ViewerId { get; private set; }
		public string Language { get; private set; }
		public string AccessToken { get; private set; }
	}
}