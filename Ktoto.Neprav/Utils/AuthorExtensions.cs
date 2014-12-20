namespace Ktoto.Neprav.Utils
{
	public static class AuthorExtensions
	{

		public static string GetPageUrl(this Author author)
		{
			var url = "https://vk.com/id" + author.UserId;
			return url;
		} 
	}
}