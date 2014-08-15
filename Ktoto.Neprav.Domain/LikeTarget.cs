namespace Ktoto.Neprav.Domain
{
    public class LikeTarget
    {
        
    }

    public class Like
    {
        public virtual Author Author { get; set; }
        public virtual LikeTarget Target { get; set; }
    }
}