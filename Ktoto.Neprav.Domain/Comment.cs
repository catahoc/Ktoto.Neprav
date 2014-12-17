namespace Ktoto.Neprav
{
    public class Comment : Feed
    {
		public virtual string Text { get; set; }
        public virtual OpinionColor Opinion { get; set; }
        public virtual Feed Feed { get; set; }
    }
}