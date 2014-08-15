using FluentNHibernate.Mapping;
using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav
{
    public class CommentMapping: ClassMap<Comment>
    {
        public CommentMapping()
        {
            Id(_ => _.Id).AutoIncrement();

            Map(_ => _.Opinion);
            Map(_ => _.Text);

            References(_ => _.Author);
            References(_ => _.Theme);
        }
    }
}