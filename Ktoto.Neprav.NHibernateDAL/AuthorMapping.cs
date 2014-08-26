using FluentNHibernate.Mapping;

namespace Ktoto.Neprav
{
    public class AuthorMapping: ClassMap<Author>
    {
        public AuthorMapping()
        {
            Id(_ => _.Id).GeneratedBy.Identity();

            Map(_ => _.Sex);
            Map(_ => _.Name);
            Map(_ => _.Email);
            Map(_ => _.PwdHash);
            Map(_ => _.Salt);

            HasMany(_ => _.Themes);
            HasMany(_ => _.Comments);

			HasManyToMany(_ => _.LikedTargets);
        }
    }
}
