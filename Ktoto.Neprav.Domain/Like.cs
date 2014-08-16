namespace Ktoto.Neprav.Domain
{
	public class Like
	{
		public virtual long Id { get; set; }
		public virtual Author Author { get; set; }
		public virtual LikeTarget Target { get; set; }
	}
}