using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Ktoto.Neprav.Utils
{
	public class VkArgs : IVkArgs
	{
		private const string SECRET = "0NFgIYmnCuTxz7Avoww0";

		public VkArgs(IVkArgsSource source, HttpRequest request, HttpResponse response)
		{
			var args = source.GetVkArgs(request, response);
			ApiUrl = args.GetOrNull("vk.api_url");
			ViewerId = long.Parse(args.GetOrNull("vk.viewer_id"));
			ApiId = args.GetOrNull("vk.api_id");
			AuthKey = args.GetOrNull("vk.auth_key");
			Sid = args.GetOrNull("vk.sid");
			Secret = args.GetOrNull("vk.secret");
			Language = args.GetOrNull("vk.language");
			AccessToken = args.GetOrNull("vk.access_token");

			Verify();
		}

		private void Verify()
		{
			var feed = string.Format("{0}_{1}_{2}", ApiId, ViewerId, SECRET);
			var md5 = ToHex(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(feed)));
			if (!md5.Equals(AuthKey, StringComparison.InvariantCultureIgnoreCase))
			{
				throw new InvalidOperationException("Authorization failed. You're dirty hacker");
			}
		}
		public static string ToHex(byte[] bytes)
		{
			var result = new StringBuilder(bytes.Length * 2);

			foreach (byte t in bytes)
				result.Append(t.ToString("x2"));

			return result.ToString();
		}
		public string ApiUrl { get; private set; }
		public string ApiId { get; private set; }
		public string AuthKey { get; private set; }
		public string Sid { get; private set; }
		public string Secret { get; private set; }
		public long ViewerId { get; private set; }
		public string Language { get; private set; }
		public string AccessToken { get; private set; }
	}
}