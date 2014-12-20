namespace Ktoto.Neprav.Utils
{
	public interface IVkArgs
	{
		string ApiUrl { get; }
		string ApiId { get; }
		string Sid { get; }
		string Secret { get; }
		string ViewerId { get; }
		string Language { get; }
		string AccessToken { get; }
	}
}