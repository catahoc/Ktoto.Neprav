using FluentNHibernate.Mapping;
using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav
{
    public class AuthorMapping: ClassMap<Author>
    {
        public AuthorMapping()
        {
            Id(_ => _.Id).GeneratedBy.Identity();

            Map(_ => _.Sex);
            Map(_ => _.Name);

            HasMany(_ => _.Themes);
            HasMany(_ => _.Comments);

			HasManyToMany(_ => _.LikedTargets);
		}
    }
}
