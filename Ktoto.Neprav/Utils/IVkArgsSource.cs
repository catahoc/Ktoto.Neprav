using System.Collections.Generic;
using System.Web;

namespace Ktoto.Neprav.Utils
{
	public interface IVkArgsSource
	{
		Dictionary<string, string> GetVkArgs(HttpRequest request, HttpResponse response);
	}
}