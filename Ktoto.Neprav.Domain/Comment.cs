using System;

namespace Ktoto.Neprav.Domain
{
    public class Comment : HaveId
    {
        public virtual string Text { get; set; }
        public virtual Opinion Opinion { get; set; }
        public virtual Author Author { get; set; }
        public virtual Theme Theme { get; set; }
    }
}