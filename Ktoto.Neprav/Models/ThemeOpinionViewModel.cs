namespace Ktoto.Neprav.Models
{
	public class ThemeOpinionViewModel
	{
		private readonly OpinionColor _color;
		private readonly Comment[] _comments;

		public ThemeOpinionViewModel(OpinionColor color, Comment[] comments)
		{
			_color = color;
			_comments = comments;
		}

		public OpinionColor Color
		{
			get { return _color; }
		}

		public Comment[] Comments
		{
			get { return _comments; }
		}
	}
}