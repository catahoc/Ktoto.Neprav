namespace Ktoto.Neprav.Utils
{
	public interface IVkArgs
	{
		string ApiUrl { get; }
		string ApiId { get; }
		string AuthKey { get; }
		string Sid { get; }
		string Secret { get; }
		long ViewerId { get; }
		string Language { get; }
		string AccessToken { get; }
	}
}