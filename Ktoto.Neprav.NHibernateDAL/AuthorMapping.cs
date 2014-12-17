using FluentNHibernate.Mapping;

namespace Ktoto.Neprav
{
    public class AuthorMapping: ClassMap<Author>
    {
        public AuthorMapping()
        {
            Id(_ => _.Id).GeneratedBy.Identity();

            HasMany(_ => _.Feeds);
			HasMany(_ => _.Opinions);
        }
    }
}
