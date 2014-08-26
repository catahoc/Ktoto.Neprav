using FluentNHibernate.Mapping;

namespace Ktoto.Neprav
{
    public class CommentMapping: SubclassMap<Comment>
    {
        public CommentMapping()
        {
			KeyColumn("ID");

            Map(_ => _.Opinion);
            Map(_ => _.Text);

            References(_ => _.Author);
            References(_ => _.Theme);
        }
    }
}