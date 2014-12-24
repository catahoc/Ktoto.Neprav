using System.Collections.Generic;
using System.Web;

namespace Ktoto.Neprav.Utils
{
	public interface IVkArgsService
	{
		Dictionary<string, string> GetVkArgs(HttpRequest request);
		
		bool IsRequestFromVk(HttpRequestBase request);

		void SaveVkArgsAsCookies(HttpRequestBase request, HttpResponseBase response);
	}
}