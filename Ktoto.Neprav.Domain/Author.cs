using System.Collections.Generic;

namespace Ktoto.Neprav.Domain
{
    public class Author: HaveId
    {
        public Author()
        {
            Themes = new List<Theme>();
            Comments = new List<Comment>();
        }

        public virtual string Name { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}