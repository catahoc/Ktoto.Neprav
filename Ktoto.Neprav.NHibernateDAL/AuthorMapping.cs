using FluentNHibernate.Mapping;

namespace Ktoto.Neprav
{
    public class AuthorMapping: ClassMap<Author>
    {
        public AuthorMapping()
        {
            Id(_ => _.Id).GeneratedBy.Identity();

	        Map(_ => _.UserId);

            HasMany(_ => _.Feeds);
			HasMany(_ => _.Opinions);
        }
    }
}
