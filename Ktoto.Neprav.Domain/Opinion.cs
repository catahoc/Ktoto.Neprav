namespace Ktoto.Neprav
{
	public class Opinion
	{
		public virtual Author Author { get; set; } 
		public virtual Feed Feed { get; set; } 
		public virtual OpinionColor Color { get; set; } 
	}
}