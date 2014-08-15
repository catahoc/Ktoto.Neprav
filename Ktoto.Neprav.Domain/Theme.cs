using System.Collections.Generic;

namespace Ktoto.Neprav.Domain
{
    public class Theme : HaveId
    {
        public Theme()
        {
            Comments = new List<Comment>();
        }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Author Author { get; set; }
        public virtual string Name { get; set; }
    }
}
