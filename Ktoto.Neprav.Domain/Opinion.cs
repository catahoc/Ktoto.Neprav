namespace Ktoto.Neprav
{
	public class Opinion
	{
		public virtual Author Author { get; set; } 
		public virtual Feed Feed { get; set; } 
		public virtual OpinionColor Color { get; set; }

		private bool Equals(Opinion other)
		{
			return Equals(Author, other.Author) && Equals(Feed, other.Feed);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Author != null ? Author.GetHashCode() : 0) * 397) ^ (Feed != null ? Feed.GetHashCode() : 0);
			}
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Opinion) obj);
		}
	}
}